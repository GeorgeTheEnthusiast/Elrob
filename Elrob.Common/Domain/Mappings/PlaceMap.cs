namespace Elrob.Common.Domain.Mappings
{
    using FluentNHibernate.Mapping;

    public class PlaceMap : ClassMap<Place>
    {
        public PlaceMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Table("[Place]");
        }
    }
}