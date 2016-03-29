using FluentNHibernate.Mapping;

namespace Elrob.Terminal.Domain.Mappings
{
    public class OrderContentMap : ClassMap<OrderContent>
    {
        public OrderContentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.DocumentNumber);
            Map(x => x.Height);
            Map(x => x.PackageQuantity);
            Map(x => x.Thickness);
            Map(x => x.ToComplete);
            Map(x => x.UnitWeight);
            Map(x => x.Width);
            References(x => x.Material, "MaterialId");
            References(x => x.Order, "OrderId");
            References(x => x.Place, "PlaceId");
//            HasMany<OrderProgress>(x => x.OrderProgresses)
//                .Table("[OrderProgress]")
//                .KeyColumn("OrderContentId")
//                .Not.LazyLoad();
            Table("[OrderContent]");
        }
    }
}
