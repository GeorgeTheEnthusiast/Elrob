using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Choose
{
    public interface IPlaceChoosePresenter
    {
        Place ChoosedPlace { get; }

        DialogResult ShowDialog();

        void ShowMainView();
    }
}
