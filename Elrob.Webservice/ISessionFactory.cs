namespace Elrob.Webservice
{
    using NHibernate;

    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}