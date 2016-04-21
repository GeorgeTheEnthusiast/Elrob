using System.Linq;
using System.Windows.Forms;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class UserItemView : Form, IUserItemView
    {
        private readonly IUserItemPresenter _userItemPresenter;
        
        public bool IsInEditMode { get; set; }

        public User PassedUser { get; set; }

        public ErrorProvider LoginNameErrorProvider => loginNameErrorProvider;

        public ErrorProvider PasswordErrorProvider => passwordErrorProvider;

        public ErrorProvider CardErrorProvider => cardErrorProvider;

        public ComboBox ComboBoxGroup => comboBoxGroup;

        public ComboBox ComboBoxCard => comboBoxCard;

        public TextBox TextBoxLogin => textBoxLogin;

        public TextBox TextBoxFirstName => textBoxFirstName;

        public TextBox TextBoxLastName => textBoxLastName;

        public TextBox TextBoxPassword => textBoxPassword;

        public TextBox TextBoxRepeatPassword => textBoxRepeatPassword;

        public UserItemView()
        {
            _userItemPresenter = new UserItemPresenter(this, Program.Kernel.Get<IUserItemModel>());
            
            InitializeComponent();
            Icon = Resources.purchase_order;
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _userItemPresenter.AcceptChanges();
        }

        public User User => new User()
        {
            Id = PassedUser?.Id ?? 0,
            LoginName = textBoxLogin.Text.Trim(),
            FirstName = textBoxFirstName.Text.Trim(),
            LastName = textBoxLastName.Text.Trim(),
            Password = textBoxPassword.Text.Trim(),
            Group = comboBoxGroup.SelectedItem as Group,
            Card = comboBoxCard.SelectedItem as Card
        };

        private void control_Click(object sender, System.EventArgs e)
        {
            OnScreenKeyboardController.ShowOnScreenKeyboard();
        }
    }
}
