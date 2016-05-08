namespace Elrob.Webservice.Controllers
{
    using DocumentFormat.OpenXml.Spreadsheet;

    public interface IExcelValueParser
    {
        T ParseExcelValue<T>(Cell cell, SharedStringTable sst);
    }
}