using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Common;
using Elrob.Terminal.Controllers;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Main;
using Elrob.Terminal.Presenter.Interfaces;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Main;
using Elrob.Terminal.View.Interfaces.Main;
using Ninject;
using Card = Elrob.Terminal.Dto.Card;

namespace Elrob.Terminal.Presenter.Implementation.Main
{
    public class CardPresenter : ICardPresenter
    {
        private readonly ICardView _cardView;
        private readonly ICardModel _cardModel;
        private ICardReaderPresenter _cardReaderPresenter;
        private ICardItemPresenter _cardItemPresenter;

        public CardPresenter(ICardView cardView, ICardModel cardModel)
        {
            if (cardView == null) throw new ArgumentNullException("cardView");
            if (cardModel == null) throw new ArgumentNullException("cardModel");

            _cardView = cardView;
            _cardModel = cardModel;
        }

        public DialogResult ShowDialog()
        {
            RefreshData();

            return _cardView.ShowDialog();
        }

        public void RefreshData()
        {
            _cardView.Cards.Clear();
            var items = _cardModel.GetAllCards();
            foreach (var item in items)
            {
                _cardView.Cards.Add(item);
            }
        }

        public void ShowAddForm()
        {
            _cardReaderPresenter = Program.Kernel.Get<ICardReaderPresenter>();
            var dialogResult = _cardReaderPresenter.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                bool exist = _cardModel.IsCardExist(_cardReaderPresenter.EnteredCard.Login);

                if (exist)
                {
                    MessageBox.Show(string.Format("Karta o numerze [{0}] została już dodana!",
                        _cardReaderPresenter.EnteredCard.Login));
                    return;
                }

                _cardModel.AddCard(_cardReaderPresenter.EnteredCard);
                RefreshData();
            }
        }

        public void ShowEditForm()
        {
            var selectedRow = Helpers.GetSelectedRow<Card>(_cardView.DataGridViewCards);

            if (selectedRow == default(Card))
            {
                return;
            }

            _cardItemPresenter = Program.Kernel.Get<ICardItemPresenter>();
            var dialogResult = _cardItemPresenter.ShowDialog(selectedRow);

            if (dialogResult == DialogResult.OK)
            {
                RefreshData();
            }
        }

        public void DeleteCard()
        {
            var selectedRow = Helpers.GetSelectedRow<Card>(_cardView.DataGridViewCards);

            if (selectedRow == default(Card))
            {
                return;
            }

            if (MessageBox.Show(
                "Usunięcie tej karty spowoduje również odpięcie jej od użytkownika. Czy aby napewno chcesz usunąć tą kartę?",
                "Potwierdź",
                MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                _cardModel.DeleteCard(selectedRow);
                RefreshData();
            }
        }

        public void SetPermissions()
        {
            _cardView.ButtonAdd.Enabled = UserFactory.Instance.HasPermission(PermissionType.CardView_AddRows);
            _cardView.ButtonDelete.Enabled = UserFactory.Instance.HasPermission(PermissionType.CardView_DeleteRows);
            _cardView.ButtonEdit.Enabled = UserFactory.Instance.HasPermission(PermissionType.CardView_EditRows);
        }
    }
}
