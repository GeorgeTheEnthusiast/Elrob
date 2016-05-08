namespace Elrob.Webservice.Domain
{
    using System;

    public class OrderProgress
    {
        public virtual int Id { get; set; }

        public virtual  User User { get; set; }

        public virtual OrderContent OrderContent { get; set; }

        public virtual int Completed { get; set; }

        public virtual TimeSpan TimeSpend { get; set; }

        public virtual DateTime ProgressCreatedDate { get; set; }

        public virtual DateTime? ProgressModifiedDate { get; set; }
    }
}
