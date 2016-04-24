namespace Elrob.Webservice.Validators
{
    using System;
    using System.Linq;

    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;

    using Elrob.Webservice.Controlers;

    using NLog;

    public class SheetValidator : ISheetValidator
    {
        private readonly IExcelValueParser _excelValueParser;

        public SheetValidator(IExcelValueParser excelValueParser)
        {
            if (excelValueParser == null)
            {
                throw new ArgumentNullException(nameof(excelValueParser));
            }
            this._excelValueParser = excelValueParser;
        }

        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        public static string SheetName { get; } = "Arkusz2";

        public string ValidationMessage { get; private set; }

        public bool Validate(SpreadsheetDocument doc)
        {
            WorkbookPart workbookPart = doc.WorkbookPart;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;

            Sheet sheet = workbookPart
                        .Workbook
                        .Descendants<Sheet>()
                        .FirstOrDefault(x => x.Name == SheetName);

            if (sheet == null)
            {
                _logger.Warn("There is not sheet called {0}", SheetName);
                this.ValidationMessage = string.Format("Arkusz o nazwie '{0}' nie istnieje!", SheetName); ;
                return false;
            }

            if (sheet.State == "hidden")
            {
                _logger.Warn("Sheet [{0}] is not visible!", SheetName);
                this.ValidationMessage = string.Format("Arkusz o nazwie '{0}' jest ukryty!", SheetName); ;
                return false;
            }

            WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();

            var rows = sheetData.Elements<Row>();

            if (rows.LongCount() <= 0)
            {
                _logger.Warn("Sheet do not have cells!");
                this.ValidationMessage = string.Format("Arkusz o nazwie '{0}' nie ma rekordów!", SheetName); ;
                return false;
            }

            var rowA1 = rows.FirstOrDefault()
                .Elements<Cell>()
                .First();

            string orderName = this._excelValueParser.ParseExcelValue<string>(rowA1, sst);

            if (string.IsNullOrEmpty(orderName))
            {
                _logger.Warn("Order name is not in the A1 cell!");
                this.ValidationMessage = "Nazwa zamówienia nie znajduje się w komórce A1!"; ;
                return false;
            }

            var rowA3 = rows.Skip(2)
                .First()
                .Elements<Cell>()
                .First();

            string idColumn = this._excelValueParser.ParseExcelValue<string>(rowA3, sst);

            if (string.IsNullOrEmpty(idColumn) || idColumn.Trim() != "ID")
            {
                _logger.Warn("The column header 'ID' is not in the A3 cell!");
                this.ValidationMessage = "Nagłówek kolumny 'ID' nie znajduje się w komórce A3!"; ;
                return false;
            }

            return true;
        }
    }
}