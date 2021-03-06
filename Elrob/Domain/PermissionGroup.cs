﻿namespace Elrob.Terminal.Domain
{
    public class PermissionGroup
    {
        public virtual Permission Permission { get; set; }

        public virtual Group Group { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as PermissionGroup;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Group.Id == other.Group.Id &&
                this.Permission.Id == other.Permission.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Group.GetHashCode();
                hash = (hash * 31) ^ Permission.GetHashCode();

                return hash;
            }
        }
    }
}
