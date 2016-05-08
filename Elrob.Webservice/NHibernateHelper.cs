namespace Elrob.Webservice
{
    using Elrob.Webservice.Domain;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(c => c.FromConnectionStringWithKey("Elrob.Terminal.Properties.Settings.ElrobConnectionString"))
                    .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<User>()
                              .AddFromAssemblyOf<Place>()
                              .AddFromAssemblyOf<Order>()
                              .AddFromAssemblyOf<OrderContent>()
                              .AddFromAssemblyOf<Material>()
                              )
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
