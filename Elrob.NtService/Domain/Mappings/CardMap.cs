namespace Elrob.NtService.Domain.Mappings
{
    using FluentNHibernate.Mapping;

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
