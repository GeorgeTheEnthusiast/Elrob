﻿using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Elrob.Terminal.Domain.Mappings
{
    public class OrderProgressMap : ClassMap<OrderProgress>
    {
        public OrderProgressMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Completed);
            Map(x => x.ProgressCreatedDate);
            Map(x => x.ProgressModifiedDate).Nullable();
            Map(x => x.TimeSpend).CustomType<TimeAsTimeSpanType>();
            References(x => x.User, "UserId");
            References(x => x.OrderContent, "OrderContentId");
            Table("[OrderProgress]");
        }
    }
}
