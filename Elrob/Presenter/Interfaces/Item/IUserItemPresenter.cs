using System.Collections.Generic;
using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IUserItemPresenter
    {
        DialogResult ShowDialog(User user);

        void AcceptChanges();
    }
}
