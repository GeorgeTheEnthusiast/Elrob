using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter;
using Elrob.Terminal.Presenter.Implementation.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.Properties;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;

namespace Elrob.Terminal.View.Implementations.Main
{
    public partial class CardView : Form, ICardView
    {
        private readonly ICardPresenter _cardPresenter;

        public CustomBindingList<Card> Cards { get; set; }

        public DataGridView DataGridViewCards => dataGridViewCards;
        
        public Button ButtonAdd => buttonAdd;

        public Button ButtonDelete => buttonEdit;

        public Button ButtonEdit => buttonEdit;

        public CardView()
        {
            _cardPresenter = new CardPresenter(this, Program.Kernel.Get<ICardModel>());

            InitializeComponent();

            dataGridViewCards.AutoGenerateColumns = false;
            dataGridViewCards.DataSource = Cards = new CustomBindingList<Card>();
            Icon = Resources.purchase_order;

            _cardPresenter.SetPermissions();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _cardPresenter.ShowAddForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _cardPresenter.DeleteCard();
        }

        private void dataGridViewCards_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Helpers.SortDataGridView(dataGridViewCards, e.ColumnIndex);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _cardPresenter.ShowEditForm();
        }
    }
}
