namespace Elrob.Webservice.Controlers
{
    using DocumentFormat.OpenXml.Spreadsheet;

    public interface IExcelValueParser
    {
        T ParseExcelValue<T>(Cell cell, SharedStringTable sst);
    }
}