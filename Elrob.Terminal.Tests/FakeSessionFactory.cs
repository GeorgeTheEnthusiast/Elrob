using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elrob.Terminal.Tests
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;

    using ISessionFactory = Elrob.Common.DataAccess.ISessionFactory;

    public class FakeSessionFactory : ISessionFactory
    {
        public ISession OpenSession()
        {
            NHibernate.ISessionFactory sessionFactory = Fluently.Configure()
                              .Database(() => SQLiteConfiguration.Standard.InMemory().ShowSql())
                              .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(Elrob.Common.Domain.OrderContent).Assembly))
                              .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
