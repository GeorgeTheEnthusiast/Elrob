using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Item;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Item
{
    public partial class CardItemView : Form, ICardItemView
    {
        private readonly ICardItemPresenter _cardItemPresenter;
        
        public ErrorProvider ErrorProviderName => nameErrorProvider;

        public Card Card => new Card()
        {
            Id = PassedCard?.Id ?? 0,
            Name = textBoxName.Text.Trim(),
            Login = textBoxLogin.Text.Trim(),
            Password = textBoxPassword.Text.Trim(),
        };

        public Card PassedCard { get; set; }

        public TextBox TextBoxLogin => textBoxLogin;

        public TextBox TextBoxPassword => textBoxPassword;

        public TextBox TextBoxName => textBoxName;

        public bool IsInEditMode { get; set; }

        public Material PassedMaterial { get; set; }

        public CardItemView()
        {
            _cardItemPresenter = new CardItemPresenter(this, Program.Kernel.Get<ICardItemModel>());
            
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _cardItemPresenter.AcceptChanges();
        }
    }
}
