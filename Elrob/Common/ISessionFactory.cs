namespace Elrob.Terminal.Common
{
    using NHibernate;

    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}