using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces;
using Elrob.Terminal.Model.Interfaces.Choose;
using Elrob.Terminal.Presenter.Implementation;
using Elrob.Terminal.Presenter.Implementation.Choose;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Choose;
using Elrob.Terminal.View.Interfaces;
using Elrob.Terminal.View.Interfaces.Choose;
using Ninject;

namespace Elrob.Terminal.View.Implementations
{
    public partial class CardReaderView : Form, ICardReaderView
    {
        private ICardReaderPresenter _cardReaderPresenter;

        public CardReaderView()
        {
            InitializeComponent();

            _cardReaderPresenter = new CardReaderPresenter(this, Program.Kernel.Get<ICardReaderModel>());
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public string EnteredText
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
    }
}
