namespace Elrob.NtService.Dto
{
    using System;

    public class OrderProgress
    {
        public int Id { get; set; }

        public User User { get; set; }

        public OrderContent OrderContent { get; set; }

        public int Completed { get; set; }

        public TimeSpan TimeSpend { get; set; }

        public DateTime ProgressCreatedDate { get; set; }

        public DateTime? ProgressModifiedDate { get; set; }
    }
}
