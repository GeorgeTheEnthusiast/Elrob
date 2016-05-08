namespace Elrob.Webservice.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class OrderContentMap : ClassMap<OrderContent>
    {
        public OrderContentMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.DocumentNumber);
            Map(x => x.Height).Nullable();
            Map(x => x.PackageQuantity);
            Map(x => x.Thickness).Nullable();
            Map(x => x.ToComplete);
            Map(x => x.UnitWeight);
            Map(x => x.Width).Nullable();
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
