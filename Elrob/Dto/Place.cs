using System;
using System.Collections.Generic;

namespace Elrob.Terminal.Dto
{
    public class Place : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            Place comparingObject = obj as Place;

            if (comparingObject == null)
            {
                return 0;
            }

            return String.Compare(Name, comparingObject.Name, StringComparison.Ordinal);
        }
    }

    public class PlaceComparer : IEqualityComparer<Place>
    {
        public bool Equals(Place x, Place y)
        {
            return x.Name.Equals(y.Name, StringComparison.Ordinal);
        }

        public int GetHashCode(Place obj)
        {
            return GetHashCode();
        }
    }
}
