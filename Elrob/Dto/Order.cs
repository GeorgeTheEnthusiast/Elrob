using System;

namespace Elrob.Terminal.Dto
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PercentageProgress { get; set; }

        public int TotalTimeSpend { get; set; }

        public DateTime StartDate { get; set; }
    }
}
