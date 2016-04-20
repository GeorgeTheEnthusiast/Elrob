using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Item;
using Elrob.Terminal.Presenter.Interfaces.Item;
using Elrob.Terminal.View.Interfaces.Item;

namespace Elrob.Terminal.Presenter.Implementation.Item
{
    public class CardItemPresenter : ICardItemPresenter
    {
        private readonly ICardItemView _cardItemView;
        private readonly ICardItemModel _cardItemModel;

        public CardItemPresenter(ICardItemView cardItemView, ICardItemModel cardItemModel)
        {
            if (cardItemView == null) throw new ArgumentNullException("cardItemView");
            if (cardItemModel == null) throw new ArgumentNullException("cardItemModel");

            _cardItemView = cardItemView;
            _cardItemModel = cardItemModel;
        }

        public void AcceptChanges()
        {
            if (_cardItemView.IsInEditMode)
            {
                _cardItemModel.UpdateCard(_cardItemView.Card);
            }
            else
            {
                
            }

            _cardItemView.DialogResult = DialogResult.OK;
        }

        public DialogResult ShowDialog(Card card)
        {
            _cardItemView.PassedCard = card;

            if (_cardItemView.PassedCard != null)
            {
                _cardItemView.IsInEditMode = true;
                _cardItemView.TextBoxName.Text = card.Name;
                _cardItemView.TextBoxLogin.Text = card.Login;
                _cardItemView.TextBoxPassword.Text = card.Password;
            }
            else
            {
                _cardItemView.IsInEditMode = false;
            }

            return _cardItemView.ShowDialog();
        }
    }
}
