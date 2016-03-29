using System.Collections.Generic;
using Elrob.Terminal.Dto;

namespace Elrob.Terminal.Presenter.Interfaces.Main
{
    public interface IMaterialPresenter
    {
        List<Material> GetAllMaterials();

        bool DeleteMaterial(Material material);

        void ShowDialog();

        void RefreshData();
    }
}
