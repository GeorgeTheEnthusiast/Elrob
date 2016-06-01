namespace Elrob.NtService.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.StartDate).CustomType<NHibernate.Type.DateType>();
//            HasMany<OrderContent>(x => x.OrderContents)
//                .KeyColumn("OrderId")
//                .Table("[OrderContent]")
//                .Not.LazyLoad();
            Table("[Order]");
        }
    }
}
