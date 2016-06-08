namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    using NHibernate.Type;

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.StartDate).CustomType<DateType>();
            Table("[Order]");
        }
    }
}