using System.Windows.Forms;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Item
{
    public interface IMaterialItemPresenter
    {
        void UpdateMaterial(Material material);

        void AddMaterial(Material material);

        DialogResult ShowDialog(Material material);

        bool IsMaterialExist(string materialName);
    }
}
