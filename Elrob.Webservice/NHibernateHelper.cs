namespace Elrob.Webservice
{
    using System.Reflection;

    using Elrob.Webservice.Domain;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

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
