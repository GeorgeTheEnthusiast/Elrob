using System;
using System.Windows.Forms;
using Elrob.Terminal.Model.Interfaces.Other;
using Elrob.Terminal.Presenter.Implementation.Other;
using Elrob.Terminal.Presenter.Interfaces.Other;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Other;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Other
{
    public partial class CardReaderView : Form, ICardReaderView
    {
        private ICardReaderPresenter _cardReaderPresenter;

        public CardReaderView()
        {
            InitializeComponent();

            _cardReaderPresenter = new CardReaderPresenter(this, Program.Kernel.Get<ICardReaderModel>());
            Icon = Resources.purchase_order;
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
