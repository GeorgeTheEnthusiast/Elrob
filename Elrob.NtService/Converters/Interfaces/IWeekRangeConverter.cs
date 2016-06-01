namespace Elrob.NtService.Converters.Interfaces
{
    using System;

    using Elrob.NtService.Dto;

    public interface IWeekRangeConverter
    {
        WeekRange GetWeekRange(DateTime dateTime);
    }
}