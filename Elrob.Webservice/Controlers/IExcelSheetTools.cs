namespace Elrob.Webservice.Controlers
{
    public interface IExcelSheetTools
    {
        string GetColumnName(string cellReference);

        int? GetColumnIndexFromName(string columnName);
    }
}