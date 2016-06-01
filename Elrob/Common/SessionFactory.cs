using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elrob.Terminal.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Elrob.Terminal.Common
{
    using System.Reflection;

    public class SessionFactory : ISessionFactory
    {
        public ISession OpenSession()
        {
            NHibernate.ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(c => c.FromConnectionStringWithKey("Elrob.Terminal.Properties.Settings.ElrobConnectionString"))
                    .ShowSql()
                )
               .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaExport(cfg).Create(false, false);
                    //cfg.SetInterceptor(new SqlStatementInterceptor());
                })
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
