using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.Service_References.ExcelServiceServiceReference;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;
using NLog;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainView _mainView;
        private readonly IMainModel _mainModel;
        private readonly IOrderContentConverter _orderContentConverter;
        private Task<ImportDataResponse> excelTask;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        private IOrderPreviewPresenter _orderPreviewPresenter;
        private IOrderChoosePresenter _orderChoosePresenter;
        private IPlaceChoosePresenter _placeChoosePresenter;
        private IOrderContentChoosePresenter _orderContentChoosePresenter;
        private IOrderProgressPresenter _orderProgressPresenter;

        public MainPresenter(IMainView mainView, IMainModel mainModel, IOrderContentConverter orderContentConverter)
        {
            if (mainView == null) throw new ArgumentNullException("mainView");
            if (mainModel == null) throw new ArgumentNullException("mainModel");
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");

            _mainView = mainView;
            _mainModel = mainModel;
            _orderContentConverter = orderContentConverter;
        }

        public User GetUser(string loginName)
        {
            return _mainModel.GetUserByLoginName(loginName);
        }
        
        public DialogResult ShowDialog()
        {
            _mainView.TextBoxUserName.Text = string.Format("{0} {1}", UserFactory.Instance.LoggedUser.FirstName, UserFactory.Instance.LoggedUser.LastName); ;
            InactivityChecker.Instance.StartTimer();

            return _mainView.ShowDialog();
        }

        public void ImportOrder()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "*.xlsx|*.xlsx",
                Multiselect = false,
                Title = "Wybierz plik Excel z zamówieniem do zaimportowania"
            };

            var dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            byte[] fileBytes;

            try
            {
                fileBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
            catch (IOException ex)
            {
                _logger.Error("Excel file is being used by other process!");

                MessageBox.Show("Plik jest używany przez inną aplikację. Zamknij ją, a następnie spróbuj ponownie.",
                    "Brak dostępu do pliku", MessageBoxButtons.OK);

                return;
            }

            OrderPreviewViewModel orderPreviewViewModel;

            using (var serviceClient = new ExcelServiceClient())
            {
                ImportDataRequest importDataRequest = new ImportDataRequest()
                {
                    FileBytes = fileBytes,
                    FileName = openFileDialog.SafeFileName
                };
                try
                {
                    var response = serviceClient.ImportData(importDataRequest);

                    if (!string.IsNullOrEmpty(response.ResponseMessage))
                    {
                        MessageBox.Show(response.ResponseMessage);
                        return;
                    }

                    _mainView.ButtonImport.Enabled = false;
                    orderPreviewViewModel = AfterImportData(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas importu danych na serwerze. Skontaktuj się z administratorem.");
                    _logger.Error(ex);
                    return;
                }
                finally
                {
                    _mainView.ButtonImport.Enabled = true;
                }
            }

            _orderPreviewPresenter = Program.Kernel.Get<IOrderPreviewPresenter>();
            _orderPreviewPresenter.ShowDialog(orderPreviewViewModel);
        }

        public void ShowOrderProgressView()
        {
            _orderChoosePresenter = Program.Kernel.Get<IOrderChoosePresenter>();
            var orderDialogResult = _orderChoosePresenter.ShowDialog();

            if (orderDialogResult == DialogResult.OK)
            {
                _placeChoosePresenter = Program.Kernel.Get<IPlaceChoosePresenter>();
                var placeDialogResult = _placeChoosePresenter.ShowDialog();

                if (placeDialogResult == DialogResult.OK)
                {
                    _orderContentChoosePresenter = Program.Kernel.Get<IOrderContentChoosePresenter>();
                    var orderContentDialogResult =
                        _orderContentChoosePresenter.ShowDialog(_orderChoosePresenter.ChoosedOrder,
                            _placeChoosePresenter.ChoosedPlace);

                    if (orderContentDialogResult == DialogResult.OK)
                    {
                        _orderProgressPresenter = Program.Kernel.Get<IOrderProgressPresenter>();
                        _orderProgressPresenter.ShowDialog(_orderContentChoosePresenter.ChoosedOrderContent, _placeChoosePresenter.ChoosedPlace);
                    }
                }
            }
        }

        public void SetPermissions()
        {
            _mainView.ButtonImport.Enabled = UserFactory.Instance.HasPermission(PermissionType.MainView_RunImport);
            _mainView.ButtonMaterials.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_View);
            _mainView.ButtonOrders.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_View);
            _mainView.ButtonPlaces.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_View);
            _mainView.ButtonUsers.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_View);
            _mainView.ButtonGroups.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_View);
            _mainView.ButtonOrderProgress.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_View);
        }

        private OrderPreviewViewModel AfterImportData(ImportDataResponse importDataResponse)
        {
            _mainView.UseWaitCursor = false;

            if (importDataResponse.OrderContents.Any())
            {
                var orderContent = _orderContentConverter.Convert(importDataResponse.OrderContents.ToList());
                var orderViewModel = new OrderPreviewViewModel()
                {
                    Order = orderContent[0].Order,
                    Materials = orderContent.Select(x => x.Material).Distinct(new MaterialComparer()).ToList(),
                    Places = orderContent.Select(x => x.Place).Distinct(new PlaceComparer()).ToList(),
                    OrderContents = orderContent
                };

                int index = 0;
                foreach (var material in orderViewModel.Materials)
                {
                    material.Id = index++;
                }
                index = 0;
                foreach (var place in orderViewModel.Places)
                {
                    place.Id = index++;
                }
                foreach (var oc in orderViewModel.OrderContents)
                {
                    int materialId = orderViewModel.Materials.First(x => x.Name == oc.Material.Name).Id;
                    oc.Material.Id = materialId;
                    int placeId = orderViewModel.Places.First(x => x.Name == oc.Place.Name).Id;
                    oc.Place.Id = placeId;
                }
                orderViewModel.Materials.Sort((material1, material2) => String.Compare(material1.Name, material2.Name, StringComparison.Ordinal));
                orderViewModel.Places.Sort((p1, p2) => String.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

                return orderViewModel;
            }
            else
            {
                MessageBox.Show(
                    "Coś poszło nie tak przy imporcie danych, skontaktuj się z administratorem systemu!");

                return null;
            }
        }
    }
}
