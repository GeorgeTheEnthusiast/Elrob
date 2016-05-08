namespace Elrob.Webservice.Controllers
{
    public interface IExcelSheetTools
    {
        string GetColumnName(string cellReference);

        int? GetColumnIndexFromName(string columnName);
    }
}