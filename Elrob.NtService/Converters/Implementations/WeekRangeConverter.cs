namespace Elrob.NtService.Converters.Implementations
{
    using System;

    using Elrob.NtService.Converters.Interfaces;
    using Elrob.NtService.Dto;

    public class WeekRangeConverter : IWeekRangeConverter
    {
        public WeekRange GetWeekRange(DateTime dateTime)
        {
            int daysDifferenceFromMonday = 0;
            WeekRange weekRange = new WeekRange();

            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    daysDifferenceFromMonday = 0;
                    break;
                case DayOfWeek.Tuesday:
                    daysDifferenceFromMonday = 1;
                    break;
                case DayOfWeek.Wednesday:
                    daysDifferenceFromMonday = 2;
                    break;
                case DayOfWeek.Thursday:
                    daysDifferenceFromMonday = 3;
                    break;
                case DayOfWeek.Friday:
                    daysDifferenceFromMonday = 4;
                    break;
                case DayOfWeek.Saturday:
                    daysDifferenceFromMonday = 5;
                    break;
                case DayOfWeek.Sunday:
                    daysDifferenceFromMonday = 6;
                    break;
            }

            weekRange.StartDate = dateTime.AddDays(-daysDifferenceFromMonday);
            weekRange.EndDate = dateTime.AddDays(6 - daysDifferenceFromMonday);

            return weekRange;
        }
    }
}