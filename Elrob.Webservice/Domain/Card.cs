namespace Elrob.Webservice.Domain
{
    public class Card
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Name { get; set; }
    }
}
