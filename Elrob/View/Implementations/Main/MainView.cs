using System;
using System.Diagnostics;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class MainView : Form, IMainView
    {
        private readonly IMainPresenter _mainPresenter;
        private IMaterialPresenter _materialPresenter;
        private IPlacePresenter _placePresenter;
        private IOrderPresenter _orderPresenter;
        private IUserPresenter _userPresenter;
        private IGroupPresenter _groupPresenter;
        
        public MainView()
        {
            _mainPresenter = new MainPresenter(this, Program.Kernel.Get<IMainModel>(), Program.Kernel.Get<IOrderContentConverter>());
            
            InitializeComponent();
            
            ButtonImport.Enabled = UserFactory.Instance.HasPermission(PermissionType.MainView_RunImport);
            buttonMaterials.Enabled = UserFactory.Instance.HasPermission(PermissionType.MaterialView_View);
            buttonOrders.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderView_View);
            buttonPlaces.Enabled = UserFactory.Instance.HasPermission(PermissionType.PlaceView_View);
            buttonUsers.Enabled = UserFactory.Instance.HasPermission(PermissionType.UserView_View);
            buttonGroups.Enabled = UserFactory.Instance.HasPermission(PermissionType.GroupView_View);
            buttonOrderProgress.Enabled = UserFactory.Instance.HasPermission(PermissionType.OrderProgressView_View);
        }

        public Button ButtonImport => buttonImport;

        public TextBox TextBoxUserName => textBoxUserName;

        private void buttonImport_Click(object sender, EventArgs e)
        {
            _mainPresenter.ImportOrder();
        }

        private void buttonMaterials_Click(object sender, EventArgs e)
        {
            _materialPresenter = Program.Kernel.Get<IMaterialPresenter>();
            _materialPresenter.ShowDialog();
        }

        private void buttonPlaces_Click(object sender, EventArgs e)
        {
            _placePresenter = Program.Kernel.Get<IPlacePresenter>();
            _placePresenter.ShowDialog();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            _orderPresenter = Program.Kernel.Get<IOrderPresenter>();
            _orderPresenter.ShowDialog();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            _userPresenter = Program.Kernel.Get<IUserPresenter>();
            _userPresenter.ShowDialog();
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            _groupPresenter = Program.Kernel.Get<IGroupPresenter>();
            _groupPresenter.ShowDialog();
        }

        private void buttonOrderProgress_Click(object sender, EventArgs e)
        {
            _mainPresenter.ShowOrderProgressView();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            InactivityChecker.Instance.StopTimer();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}