using MaterialDto = Elrob.Terminal.Dto.Material;

namespace Elrob.Terminal.Model.Interfaces.Item
{
    public interface IMaterialItemModel
    {
        void AddMaterial(MaterialDto material);

        void UpdateMaterial(MaterialDto material);

        bool IsMaterialExist(string materialName);
    }
}
