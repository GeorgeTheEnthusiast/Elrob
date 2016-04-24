namespace Elrob.Webservice.Validators
{
    using DocumentFormat.OpenXml.Packaging;

    public interface ISheetValidator
    {
        bool Validate(SpreadsheetDocument doc);

        string ValidationMessage { get; }
    }
}