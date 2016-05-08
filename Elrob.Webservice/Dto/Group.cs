namespace Elrob.Webservice.Dto
{
    using System;
    using System.Collections.Generic;

    public class Group : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Permission> Permissions { get; set; }

        public override string ToString() => this.Name;

        public int CompareTo(object obj)
        {
            Group comparingObject = obj as Group;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(this.Name, comparingObject.Name, StringComparison.Ordinal);
        }
    }
}
