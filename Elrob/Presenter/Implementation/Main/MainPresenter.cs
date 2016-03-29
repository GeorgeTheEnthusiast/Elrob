using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Dto;
using Elrob.Terminal.ExcelServiceServiceReference;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View;
using Elrob.Terminal.View.Interfaces.Main;
using NLog;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainView _mainView;
        private readonly IMainModel _mainModel;
        private readonly IOrderContentConverter _orderContentConverter;
        private Task<Elrob.Terminal.ExcelServiceServiceReference.ImportDataResponse> excelTask;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

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

        public void ImportData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "*.xlsx|*.xlsx",
                Multiselect = false,
                Title = "Wybierz plik Excel z zamówieniem do zaimportowania"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] fileBytes = null;

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
                        AfterImportData(response);
                    }
                    catch (FaultException<FileWithThatNameAlreadyExistException> ex)
                    {
                        MessageBox.Show("Plik o tej nazwie został już zaimportowany do systemu!");
                    }
                   
                }
            }
        }

        public event EventHandler<OrderPreviewViewModel> ImportDataCompleted;

        public DialogResult ShowDialog()
        {
            return _mainView.ShowDialog();
        }

        private void AfterImportData(ExcelServiceServiceReference.ImportDataResponse importDataResponse)
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
                    //oc.MaterialId = materialId;
                    oc.Material.Id = materialId;
                    int placeId = orderViewModel.Places.First(x => x.Name == oc.Place.Name).Id;
                    //oc.PlaceId = placeId;
                    oc.Place.Id = placeId;
                }
                orderViewModel.Materials.Sort((material1, material2) => String.Compare(material1.Name, material2.Name, StringComparison.Ordinal));
                orderViewModel.Places.Sort((p1, p2) => String.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

                OnImportDataCompleted(orderViewModel);
            }
            else
            {
                MessageBox.Show(
                    "Coś poszło nie tak przy imporcie danych, skontaktuj się z administratorem systemu!");
            }

            Common.UISafeThread.SetControlPropertyThreadSafe(_mainView.ButtonImport, "Enabled", true);
        }

        protected void OnImportDataCompleted(OrderPreviewViewModel orderViewModel)
        {
            if (ImportDataCompleted != null)
            {
                ImportDataCompleted(this, orderViewModel);
            }
        }
    }
}
