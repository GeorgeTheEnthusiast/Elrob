namespace Elrob.Webservice.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class PermissionMap : ClassMap<Permission>
    {
        public PermissionMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.DisplayName);
//            HasManyToMany(x => x.Groups)
//                .Table("[PermissionGroup]")
//                .ParentKeyColumn("PermissionId")
//                .ChildKeyColumn("GroupId")
//                .Cascade.All();
            Table("[Permission]");
        }
    }
}
