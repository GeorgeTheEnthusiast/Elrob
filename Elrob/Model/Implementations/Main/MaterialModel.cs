using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Main;
using dto = Elrob.Terminal.Dto;
using domain = Elrob.Terminal.Domain;

namespace Elrob.Terminal.Model.Implementations.Main
{
    public class MaterialModel : IMaterialModel
    {
        private readonly IMaterialConverter _materialConverter;

        private ISessionFactory _sessionFactory;

        public MaterialModel( 
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

        public List<dto.Material> GetAllMaterials()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var domain = session.QueryOver<Domain.Material>()
                    .List()
                    .ToList();

                var dto = _materialConverter.Convert(domain);

                return dto;
            }
        }

        public bool DeleteMaterial(dto.Material material)
        {
            var domain = _materialConverter.Convert(material);

            using (var session = _sessionFactory.OpenSession())
            {
                var existInOrderContentCount = session.QueryOver<domain.OrderContent>()
                    .Where(x => x.Material.Id == domain.Id)
                    .RowCount();

                if (existInOrderContentCount > 0)
                {
                    return false;
                }

                session.Delete(domain);
                session.Flush();

                return true;
            }
        }
    }
}
