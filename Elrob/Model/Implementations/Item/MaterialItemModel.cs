using System;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Item;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Item
{
    public class MaterialItemModel : IMaterialItemModel
    {
        private readonly IMaterialConverter _materialConverter;

        public MaterialItemModel( 
            IMaterialConverter materialConverter)
        {
            if (materialConverter == null) throw new ArgumentNullException("materialConverter");
            
            _materialConverter = materialConverter;
        }

        public void AddMaterial(dto.Material material)
        {
            var domain = _materialConverter.Convert(material);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateMaterial(dto.Material material)
        {
            var domain = _materialConverter.Convert(material);

            using (var session = NHibernateHelper.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsMaterialExist(string materialName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Material>()
                    .Where(x => x.Name == materialName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
