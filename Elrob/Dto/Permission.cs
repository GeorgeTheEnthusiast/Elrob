using System;
using System.Collections.Generic;

namespace Elrob.Terminal.Dto
{
    public class Permission : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IList<Group> Groups { get; set; }

        public override string ToString() => DisplayName;

        public int CompareTo(object obj)
        {
            Permission comparingObject = obj as Permission;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(DisplayName, comparingObject.DisplayName, StringComparison.Ordinal);
        }
    }
}
