using System.Collections.Generic;

namespace Elrob.Terminal.Domain
{
    public class Permission
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual IList<Group> Groups { get; set; } 
    }
}
