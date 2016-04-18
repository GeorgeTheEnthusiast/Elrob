using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderContentPresenter
    {
        DialogResult ShowDialog(Order order, Place place);

        void RefreshData(Order order, Place place);

        void ShowAddForm();

        void ShowEditForm();

        void DeleteOrderContent();

        void SetPermissions();
    }
}
