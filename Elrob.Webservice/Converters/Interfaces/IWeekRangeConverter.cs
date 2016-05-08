namespace Elrob.Webservice.Converters.Interfaces
{
    using System;

    using Elrob.Webservice.Dto;

    public interface IWeekRangeConverter
    {
        WeekRange GetWeekRange(DateTime dateTime);
    }
}