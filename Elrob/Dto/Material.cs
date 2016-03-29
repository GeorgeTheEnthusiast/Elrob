using System;
using System.Collections;
using System.Collections.Generic;

namespace Elrob.Terminal.Dto
{
    public class Material : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            Material comparingObject = obj as Material;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(Name, comparingObject.Name, StringComparison.Ordinal);
        }
    }

    public class MaterialComparer : IEqualityComparer<Material>
    {
        public bool Equals(Material x, Material y)
        {
            return x.Name.Equals(y.Name, StringComparison.Ordinal);
        }

        public int GetHashCode(Material obj)
        {
            return GetHashCode();
        }
    }
}
