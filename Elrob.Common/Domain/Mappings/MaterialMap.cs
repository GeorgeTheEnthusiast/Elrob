namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

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