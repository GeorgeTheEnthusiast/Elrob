using System;
using System.Collections.Generic;

namespace Elrob.Terminal.Dto
{
    public class Group : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Permission> Permissions { get; set; }

        public override string ToString() => Name;

        public int CompareTo(object obj)
        {
            Group comparingObject = obj as Group;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(Name, comparingObject.Name, StringComparison.Ordinal);
        }
    }
}
