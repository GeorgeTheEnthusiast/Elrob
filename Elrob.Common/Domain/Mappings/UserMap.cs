namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.LoginName);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Password);
            References(x => x.Group, "GroupId");
            References(x => x.Card, "CardId");
            Table("[User]");
        }
    }
}