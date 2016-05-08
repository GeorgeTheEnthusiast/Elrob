namespace Elrob.Webservice.Domain
{
    using System.Collections.Generic;

    public class Group
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Permission> Permissions { get; set; } 
    }
}
