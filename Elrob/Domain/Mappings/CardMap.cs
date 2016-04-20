using FluentNHibernate.Mapping;

namespace Elrob.Terminal.Domain.Mappings
{
    public class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.Name);
            Table("[Card]");
        }
    }
}
