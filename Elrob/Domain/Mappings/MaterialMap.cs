using FluentNHibernate.Mapping;

namespace Elrob.Terminal.Domain.Mappings
{
    public class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Table("[Material]");
        }
    }
}
