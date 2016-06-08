namespace Elrob.Common.DataAccess
{
    using NHibernate;

    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}