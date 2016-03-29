using System;

namespace Elrob.Terminal.Dto
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Group Group { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public override string ToString() => LoginName;
    }
}
