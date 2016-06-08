namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class PermissionGroupMap : ClassMap<PermissionGroup>
    {
        public PermissionGroupMap()
        {
            CompositeId().KeyReference(x => x.Group, "GroupId").KeyReference(x => x.Permission, "PermissionId");
            Table("[PermissionGroup]");
        }
    }
}