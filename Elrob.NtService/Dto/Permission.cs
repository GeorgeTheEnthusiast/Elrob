namespace Elrob.NtService.Dto
{
    using System;

    public class Permission : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        //public IList<Group> Groups { get; set; }

        public override string ToString() => this.DisplayName;

        public int CompareTo(object obj)
        {
            Permission comparingObject = obj as Permission;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(this.DisplayName, comparingObject.DisplayName, StringComparison.Ordinal);
        }
    }
}
