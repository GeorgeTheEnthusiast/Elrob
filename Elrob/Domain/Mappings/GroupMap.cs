using FluentNHibernate.Mapping;

namespace Elrob.Terminal.Domain.Mappings
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasManyToMany(x => x.Permissions)
                .Table("[PermissionGroup]")
                .ParentKeyColumn("GroupId")
                .ChildKeyColumn("PermissionId")
                .Not.LazyLoad();
            Table("[Group]");
        }
    }
}
