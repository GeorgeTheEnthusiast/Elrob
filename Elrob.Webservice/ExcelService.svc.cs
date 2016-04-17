using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Elrob.Webservice.Controlers;
using Elrob.Webservice.Dto;
using NLog;
using DataTable = DocumentFormat.OpenXml.Drawing.Charts.DataTable;

namespace Elrob.Webservice
{
    public class ExcelService : IExcelService
    {
        private readonly IFileController _fileController;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        public string SheetName { get; } = "Arkusz2";

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
            
            _logger.Debug("Saving excel file to server...");
            string filePath = _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;

                    //var sheet = workbookPart.Workbook.Sheets.ChildElements.FirstOrDefault(x => x.GetAttributes().Any(y => y.LocalName == "name" && y.Value == SheetName));
                    Sheet sheet = workbookPart
                        .Workbook
                        .Descendants<Sheet>()
                        .FirstOrDefault(x => x.Name == SheetName);

                    if (sheet == null)
                    {
                        _logger.Warn("There is not sheet called {0}", SheetName);
                        response.ResponseMessage = string.Format("Arkusz o nazwie '{0}' nie istnieje!", SheetName); ;
                        return response;
                    }

                    if (sheet.State == "hidden")
                    {
                        _logger.Warn("Sheet [{0}] is not visible!", SheetName);
                        response.ResponseMessage = string.Format("Arkusz o nazwie '{0}' jest ukryty!", SheetName); ;
                        return response;
                    }

                    WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();

                    var rows = sheetData.Elements<Row>();

                    if (rows.LongCount() <= 0)
                    {
                        _logger.Warn("Sheet do not have cells!");
                        response.ResponseMessage = string.Format("Arkusz o nazwie '{0}' nie ma rekordów!", SheetName); ;
                        return response;
                    }

                    var rowA1 = rows.FirstOrDefault()
                        .Elements<Cell>()
                        .First();

                    string orderName = ParseExcelValue<string>(rowA1, sst);

                    if (string.IsNullOrEmpty(orderName))
                    {
                        _logger.Warn("Order name is not in the A1 cell!");
                        response.ResponseMessage = "Nazwa zamówienia nie znajduje się w komórce A1!"; ;
                        return response;
                    }

                    var rowA3 = rows.Skip(2)
                        .First()
                        .Elements<Cell>()
                        .First();

                    string idColumn = ParseExcelValue<string>(rowA3, sst);

                    if (string.IsNullOrEmpty(idColumn) || idColumn.Trim() != "ID")
                    {
                        _logger.Warn("The column header 'ID' is not in the A3 cell!");
                        response.ResponseMessage = "Nagłówek kolumny 'ID' nie znajduje się w komórce A3!"; ;
                        return response;
                    }

                    var rowsList = rows
                        .Skip(3)
                        .ToList();
                    Order order = new Order()
                    {
                        Name = orderName
                    };

                    _logger.Debug("Reading rows...");

                    try
                    {
                        foreach (var row in rowsList)
                        {
                            OrderContent content = new OrderContent()
                            {
                                Order = order
                            };
                            var cells = row.Elements<Cell>().ToList();

                            int columnIndex = 0;
                            foreach (Cell cell in cells)
                            {
                                // Gets the column index of the cell with data
                                int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                            
                                if (columnIndex < cellColumnIndex)
                                {
                                    do
                                    {
                                        //Insert blank data here;
                                        columnIndex++;
                                    }
                                    while (columnIndex < cellColumnIndex);
                                }

                                switch (columnIndex)
                                {
                                    case 1:
                                        content.DocumentNumber = ParseExcelValue<string>(cell, sst); //Numer dokumentu
                                        break;
                                    case 2:
                                        content.Name = ParseExcelValue<string>(cell, sst); //Nazwa
                                        break;
                                    case 3:
                                        content.Place = new Place()
                                        {
                                            Name = ParseExcelValue<string>(cell, sst)  //Typ
                                        };
                                        break;
                                    case 4:
                                        content.PackageQuantity = ParseExcelValue<int>(cell, sst);  //Ilość na kpl.
                                        break;
                                    case 5:
                                        content.Material = new Material()
                                        {
                                            Name = ParseExcelValue<string>(cell, sst) //Materiał
                                        };
                                        break;
                                    case 6:
                                        content.Thickness = ParseExcelValue<decimal?>(cell, sst);   //Grubość
                                        break;
                                    case 7:
                                        content.Width = ParseExcelValue<decimal?>(cell, sst);   //Kier. X
                                        break;
                                    case 8:
                                        content.Height = ParseExcelValue<decimal?>(cell, sst);  //Kier. Y
                                        break;
                                    case 9:
                                        content.UnitWeight = ParseExcelValue<decimal>(cell, sst);  //Masa (jednostkowa)
                                        break;
                                    case 10:
                                        content.ToComplete = ParseExcelValue<int>(cell, sst);  //Do realizacji
                                        break;
                                }
                            
                                columnIndex++;
                            }
                        
                            response.OrderContents.Add(content);
                         }
                    }
                    catch (FormatException e)
                    {
                        response.ResponseMessage = e.Message;
                        return response;
                    }
                    
                    
                }
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

        private T ParseExcelValue<T>(Cell cell, SharedStringTable sst)
        {
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                int ssid = int.Parse(cell.CellValue.Text);
                string str = sst.ChildElements[ssid].InnerText;

                if (typeof (T) == typeof (string))
                {
                    return (T)(object)str.Trim();
                }
                else if (typeof (T) == typeof (int))
                {
                    int tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (int.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct int value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą całkowitą!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }
                else if (typeof (T) == typeof (decimal) ||
                    typeof(T) == typeof(decimal?))
                {
                    decimal tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct decimal value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą zmiennoprzecinkową!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }

                throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
            }
            else if (cell.CellValue != null)
            {
                string str = cell.CellValue.Text.Trim();

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)str.Trim();
                }
                else if (typeof(T) == typeof(int))
                {
                    int tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (int.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct int value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą całkowitą!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }
                else if (typeof(T) == typeof(decimal) ||
                    typeof(T) == typeof(decimal?))
                {
                    decimal tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct decimal value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową wartością zmiennoprzecinkową!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }

                throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
            }

            return default(T);
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

        private static List<char> Letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);

            return match.Value;
        }

        /// <summary>
        /// Given just the column name (no row index), it will return the zero based column index.
        /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
        /// A length of three can be implemented when needed.
        /// </summary>
        /// <param name="columnName">Column Name (ie. A or AB)</param>
        /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
        public int? GetColumnIndexFromName(string columnName)
        {
            int? columnIndex = null;

            string[] colLetters = Regex.Split(columnName, "([A-Z]+)");
            colLetters = colLetters.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            if (colLetters.Count() <= 2)
            {
                int index = 0;
                foreach (string col in colLetters)
                {
                    List<char> col1 = colLetters.ElementAt(index).ToCharArray().ToList();
                    int? indexValue = Letters.IndexOf(col1.ElementAt(index));

                    if (indexValue != -1)
                    {
                        // The first letter of a two digit column needs some extra calculations
                        if (index == 0 && colLetters.Count() == 2)
                        {
                            columnIndex = columnIndex == null ? (indexValue + 1) * 26 : columnIndex + ((indexValue + 1) * 26);
                        }
                        else
                        {
                            columnIndex = columnIndex == null ? indexValue : columnIndex + indexValue;
                        }
                    }

                    index++;
                }
            }

            return columnIndex;
        }
    }
}
