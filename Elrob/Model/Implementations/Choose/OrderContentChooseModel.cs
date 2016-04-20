﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elrob.Terminal.Common;
using Elrob.Terminal.Converters;
using Elrob.Terminal.Converters.Interfaces;
using Elrob.Terminal.Model.Interfaces.Choose;
using dto = Elrob.Terminal.Dto;

namespace Elrob.Terminal.Model.Implementations.Choose
{
    public class OrderContentChooseModel : IOrderContentChooseModel
    {
        private readonly IOrderContentConverter _orderContentConverter;

        public OrderContentChooseModel( 
            IOrderContentConverter orderContentConverter)
        {
            if (orderContentConverter == null) throw new ArgumentNullException("orderContentConverter");

            _orderContentConverter = orderContentConverter;
        }

        public List<dto.OrderContent> GetOrderContentsByOrderAndPlace(dto.Order order, dto.Place place)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderContent>()
                     .Where(x => x.Order.Id == order.Id)
                     .And(x => x.Place.Id == place.Id)
                     .List()
                     .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }

        public List<dto.OrderContent> GetOrderContentsByOrder(dto.Order order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var domain = session.QueryOver<Domain.OrderContent>()
                    .Where(x => x.Order.Id == order.Id)
                    .List()
                    .ToList();

                var dto = _orderContentConverter.Convert(domain);

                return dto;
            }
        }
    }
}
