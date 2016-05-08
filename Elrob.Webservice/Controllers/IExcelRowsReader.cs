namespace Elrob.Webservice.Controllers
{
    using System.Collections.Generic;

    using DocumentFormat.OpenXml.Packaging;

    using Elrob.Webservice.Dto;

    public interface IExcelRowsReader
    {
        List<OrderContent> ReadRows(SpreadsheetDocument doc);
    }
}