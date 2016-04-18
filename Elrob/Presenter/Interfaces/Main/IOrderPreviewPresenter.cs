using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;
using Elrob.Terminal.View;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IOrderPreviewPresenter
    {
        DialogResult ShowDialog(OrderPreviewViewModel orderPreviewViewModel);

        void ShowAddForm();

        void ShowEditForm();

        void DeleteOrderContent();

        void AcceptChanges();
    }
}
