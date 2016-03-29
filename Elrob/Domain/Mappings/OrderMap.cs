using FluentNHibernate.Mapping;

namespace Elrob.Terminal.Domain.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
//            HasMany<OrderContent>(x => x.OrderContents)
//                .KeyColumn("OrderId")
//                .Table("[OrderContent]")
//                .Not.LazyLoad();
            Table("[Order]");
        }
    }
}
