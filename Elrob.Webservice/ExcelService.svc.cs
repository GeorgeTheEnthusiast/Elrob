using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using Elrob.Webservice.Controlers;
using Elrob.Webservice.Dto;
using NLog;
using Excel = Microsoft.Office.Interop.Excel;

namespace Elrob.Webservice
{
    public class ExcelService : IExcelService
    {
        private readonly IFileController _fileController;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        private const string SheetName = "Arkusz2";

        public ExcelService() : this(new FileController(new ConfigurationManager()))
        {
            
        }

        public ExcelService(IFileController fileController)
        {
            if (fileController == null) throw new ArgumentNullException("fileController");

            _fileController = fileController;
        }

        public ImportDataResponse ImportData(ImportDataRequest importDataRequest)
        {
            if (importDataRequest == null) throw new ArgumentNullException("importDataRequest");
            
            ImportDataResponse response = new ImportDataResponse()
            {
                OrderContents = new List<OrderContent>()
            };

            _logger.Debug("Starting to import excel data...");

            _logger.Debug("Closing all excel processes...");

            var excelProcesses = Process.GetProcessesByName("EXCEL");
            foreach (var excelProcess in excelProcesses)
            {
                _logger.Debug("Closing process with Id [{0}]...", excelProcess.Id);
                excelProcess.Kill();
            }

            _logger.Debug("Saving excel file to server...");
            string filePath = _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName);

            Excel.Application excelApplication = new Excel.Application();
            _logger.Debug("Opening excel workbook...");
            Excel.Workbook workbook = excelApplication.Workbooks.Open(filePath);
            var sheet = workbook.Sheets
                .Cast<Excel.Worksheet>()
                .FirstOrDefault(x => x.Name == SheetName);

            if (sheet == null)
            {
                _logger.Warn("There is not sheet called {0}", SheetName);
                response.ResponseMessage = string.Format("Arkusz o nazwie '{0}' nie istnieje!", SheetName); ;
                return response;
            }

            if (sheet.Visible != Excel.XlSheetVisibility.xlSheetVisible)
            {
                _logger.Debug("Sheet is not visible!");
            }

            var range = sheet.UsedRange;
            int rows = range.Rows.Count;

            _logger.Debug("Rows: [{0}]", rows);

            string orderName = range.Cells[1, 1].Value2;

            if (string.IsNullOrEmpty(orderName))
            {
                _logger.Warn("Order name is not in the A1 cell!");
                response.ResponseMessage = "Nazwa zamówienia nie znajduje się w komórce A1!"; ;
                return response;
            }

            Order order = new Order()
            {
                Name = orderName
            };

            string idColumn = range.Cells[3, 1].Value2;

            if (string.IsNullOrEmpty(idColumn) || idColumn.Trim() != "ID")
            {
                _logger.Warn("The column header 'ID' is not in the A3 cell!");
                response.ResponseMessage = "Nagłówek kolumny 'ID' nie znajduje się w komórce A3!"; ;
                return response;
            }

            _logger.Debug("Reading rows...");

            for (int row = 4; row <= rows; row++)
            {
                OrderContent content = new OrderContent()
                {
                    Order = order
                };

                content.DocumentNumber = range.Cells[row, 2].Value2.ToString().Trim();  //Numer dokumentu
                content.Name = range.Cells[row, 3].Value2.ToString().Trim();    //Nazwa
                content.Place = new Place()
                {
                    Name = range.Cells[row, 4].Value2.ToString().Trim() //Typ
                };
                content.PackageQuantity = ParseExcelValue<int>(sheet, row, 5);  //Ilość na kpl.
                content.Material = new Material()
                {
                    Name = range.Cells[row, 6].Value2.ToString().Trim() //Materiał
                };
                content.Thickness = ParseExcelNullValue<decimal?>(sheet, row, 7);   //Grubość
                content.Width = ParseExcelNullValue<decimal?>(sheet, row, 8);   //Kier. X
                content.Height = ParseExcelNullValue<decimal?>(sheet, row, 9);  //Kier. Y
                content.UnitWeight = ParseExcelValue<decimal>(sheet, row, 10);  //Masa (jednostkowa)
                content.ToComplete = ParseExcelValue<int>(sheet, row, 11);  //Do realizacji

                response.OrderContents.Add(content);
            }

            _logger.Debug("Grouping data...");

            var list = (from c in response.OrderContents
                group c by
                    new
                    {
                        OrderName = c.Order.Name,
                        c.DocumentNumber,
                        c.Name,
                        PlaceName = c.Place.Name,
                        c.PackageQuantity,
                        MaterialName = c.Material.Name,
                        c.Thickness,
                        c.Width,
                        c.Height,
                        c.UnitWeight
                    }
                into grouped
                let ToCompleteSum = grouped.Sum(x => x.ToComplete)
                select new OrderContent
                {
                    DocumentNumber = grouped.Key.DocumentNumber,
                    Name = grouped.Key.Name,
                    Place = new Place
                    {
                        Name = grouped.Key.PlaceName
                    },
                    Order = new Order
                    {
                        Name = grouped.Key.OrderName
                    },
                    Material = new Material
                    {
                        Name = grouped.Key.MaterialName
                    },
                    Width = grouped.Key.Width,
                    Height = grouped.Key.Height,
                    PackageQuantity = grouped.Key.PackageQuantity,
                    Thickness = grouped.Key.Thickness,
                    UnitWeight = grouped.Key.UnitWeight,
                    ToComplete = ToCompleteSum
                }).ToList();

            response.OrderContents = list;

            _logger.Debug("Import of excel data completed successfully");

            return response;
        }

        private T ParseExcelValue<T>(Excel.Worksheet sheet, int row, int column)
        {
            var range = (Excel.Range)sheet.Cells[row, column];
            string value = range.Value.ToString();

            if (typeof(T) == typeof(int))
            {
                int tempValue;
                value = ExtractOnlyNumbers(value);

                if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out tempValue) == false)
                {
                    _logger.Warn("The value in row {0} and column {1} is not a int value! Provided value: {2}", row, column, value);

                    throw new FormatException(string.Format("The value {0} is not correct int value!", value));
                }
                return (T)(object)tempValue;
            }

            if (typeof(T) == typeof(decimal))
            {
                decimal tempValue;
                value = ExtractOnlyNumbers(value);

                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out tempValue) == false)
                {
                    _logger.Warn("The value in row {0} and column {1} is not a decimal value! Provided value: {2}", row, column, value);

                    throw new FormatException(string.Format("The value {0} is not correct decimal value!", value));
                }
                return (T)(object)tempValue;
            }

            throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
        }

        private T ParseExcelNullValue<T>(Excel.Worksheet sheet, int row, int column)
        {
            var range = (Excel.Range)sheet.Cells[row, column];
            object value = range.Value;

            if (value != null && string.IsNullOrEmpty(value.ToString()) == false)
            {
                if (typeof(T) == typeof(decimal?))
                {
                    decimal tempValue;
                    string stringValue = value.ToString();
                    stringValue = ExtractOnlyNumbers(stringValue);

                    if (
                        decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out tempValue) ==
                        false)
                    {
                        _logger.Warn("The value in row {0} and column {1} is not a decimal value! Provided value: {2}",
                            row, column, value);

                        throw new FormatException(string.Format("The value {0} is not correct decimal value!", value));
                    }

                    return (T)(object)tempValue;
                }
                else
                {
                    throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
                }
            }
            else
            {
                return (T)(object)null;
            }
        }

        private string ExtractOnlyNumbers(string value)
        {
            string result = Regex.Replace(value, "[A-Za-z]", "");

            if (CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ".")
                result = result.Replace(",", ".");
            else
                result = result.Replace(".", ",");

            return result;
        }
    }
}
