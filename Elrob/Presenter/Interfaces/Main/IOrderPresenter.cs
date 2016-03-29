using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderPresenter
    {
        void DeleteOrder(Order order);

        void UpdateOrder(Order order);

        void AddOrder(Order order);

        void ShowDialog();

        void RefreshData(Place place);
    }
}
