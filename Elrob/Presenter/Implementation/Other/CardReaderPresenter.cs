using System;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.Model.Interfaces.Other;
using Elrob.Terminal.Presenter.Interfaces.Other;
using Elrob.Terminal.View.Interfaces.Other;

namespace Elrob.Terminal.Presenter.Implementation.Other
{
    public class CardReaderPresenter : ICardReaderPresenter
    {
        private readonly ICardReaderView _cardReaderView;
        private readonly ICardReaderModel _cardReaderModel;

        public CardReaderPresenter(ICardReaderView cardReaderView, ICardReaderModel cardReaderModel)
        {
            if (cardReaderView == null) throw new ArgumentNullException("cardReaderView");
            if (cardReaderModel == null) throw new ArgumentNullException("cardReaderModel");

            _cardReaderView = cardReaderView;
            _cardReaderModel = cardReaderModel;
        }

        public Card EnteredCard { get; set; }

        public DialogResult ShowDialog()
        {
            var firstDialogResult = _cardReaderView.ShowDialog();

            if (firstDialogResult == DialogResult.OK)
            {
                string firstValue = _cardReaderView.EnteredText;
                _cardReaderView.EnteredText = "";
                var secondDialogResult = _cardReaderView.ShowDialog();

                if (secondDialogResult == DialogResult.OK)
                {
                    EnteredCard = new Card()
                    {
                        Login = firstValue,
                        Password = _cardReaderView.EnteredText
                    };
                    return DialogResult.OK;
                }
                else
                {
                    _cardReaderView.EnteredText = "";
                }
            }
            else
            {
                _cardReaderView.EnteredText = "";
            }

            return DialogResult.Cancel;
        }
    }
}
