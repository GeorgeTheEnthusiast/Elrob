namespace Elrob.NtService
{
    using NHibernate;

    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}