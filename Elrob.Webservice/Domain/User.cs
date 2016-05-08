namespace Elrob.Webservice.Domain
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Group Group { get; set; }

        public virtual string LoginName { get; set; }

        public virtual string Password { get; set; }

        public virtual Card Card { get; set; }
    }
}
