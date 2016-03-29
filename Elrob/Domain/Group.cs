using System.Collections.Generic;
using Elrob.Terminal.Domain;

namespace Elrob.Terminal.Domain
{
    public class Group
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Permission> Permissions { get; set; } 
    }
}
