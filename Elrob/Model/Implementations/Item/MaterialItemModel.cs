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

        private ISessionFactory _sessionFactory;

        public MaterialItemModel( 
            IMaterialConverter materialConverter, ISessionFactory sessionFactory)
        {
            if (materialConverter == null) throw new ArgumentNullException(nameof(materialConverter));
            if (sessionFactory == null)
            {
                throw new ArgumentNullException(nameof(sessionFactory));
            }

            _materialConverter = materialConverter;
            this._sessionFactory = sessionFactory;
        }

        public void AddMaterial(dto.Material material)
        {
            var domain = _materialConverter.Convert(material);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(domain);
            }
        }

        public void UpdateMaterial(dto.Material material)
        {
            var domain = _materialConverter.Convert(material);

            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(domain);
                session.Flush();
            }
        }

        public bool IsMaterialExist(string materialName)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var rowCount = session.QueryOver<Domain.Material>()
                    .Where(x => x.Name == materialName)
                    .RowCount();

                return rowCount > 0;
            }
        }
    }
}
