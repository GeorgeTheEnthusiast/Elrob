using System.Windows.Forms;
using Elrob.Terminal.Controllers;
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
    public partial class GroupItemView : Form, IGroupItemView
    {
        private readonly IGroupItemPresenter _groupItemPresenter;

        public GroupItemView()
        {
            _groupItemPresenter = new GroupItemPresenter(this, Program.Kernel.Get<IGroupItemModel>());
            
            InitializeComponent();
        }

        public Group FilledGroup => new Group()
        {
            Name = textBoxName.Text.Trim(),
            Id = PassedGroup?.Id ?? 0
        };

        public Group PassedGroup { get; set; }

        public ErrorProvider ErrorProviderName => nameErrorProvider;

        public TextBox TextBoxName => textBoxName;

        public bool IsInEditMode { get; set; }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            _groupItemPresenter.AcceptChanges(IsInEditMode);
        }

        private void textBoxName_Click(object sender, System.EventArgs e)
        {
            OnScreenKeyboardController.ShowOnScreenKeyboard();
        }
    }
}
