using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace Elrob.Terminal.Domain.Mappings
{
    public class PlaceMap : ClassMap<Place>
    {
        public PlaceMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
//            HasMany<OrderContent>(x => x.OrderContents)
//                .Table("[OrderContent]")
//                .KeyColumn("PlaceId")
//                .Not.LazyLoad();
            Table("[Place]");
        }
    }
}
