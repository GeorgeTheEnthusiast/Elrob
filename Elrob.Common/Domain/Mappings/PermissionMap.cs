namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class PermissionMap : ClassMap<Permission>
    {
        public PermissionMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.DisplayName);
            Table("[Permission]");
        }
    }
}