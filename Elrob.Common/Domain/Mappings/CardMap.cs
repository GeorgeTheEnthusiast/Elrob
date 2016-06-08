namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            this.Id(x => x.Id).GeneratedBy.Identity();
            this.Map(x => x.Login);
            this.Map(x => x.Password);
            this.Map(x => x.Name);
            this.Table("[Card]");
        }
    }
}