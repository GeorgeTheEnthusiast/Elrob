namespace Elrob.Webservice.Dto
{
    public class Card
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public override string ToString() => this.Name;
    }
}
