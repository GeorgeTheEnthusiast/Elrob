using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Controlers
{
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;

    using Elrob.Webservice.Dto;
    using Elrob.Webservice.Validators;

    using NLog;

    public class ExcelRowsReader : IExcelRowsReader
    {
        private readonly IExcelValueParser _excelValueParser;

        private readonly IExcelSheetTools _excelSheetTools;
        
        public ExcelRowsReader(IExcelValueParser excelValueParser, IExcelSheetTools excelSheetTools)
        {
            if (excelValueParser == null)
            {
                throw new ArgumentNullException(nameof(excelValueParser));
            }
            this._excelValueParser = excelValueParser;
            this._excelSheetTools = excelSheetTools;
        }

        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public List<OrderContent> ReadRows(SpreadsheetDocument doc)
        {
            var result = new List<OrderContent>();
            WorkbookPart workbookPart = doc.WorkbookPart;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;

            Sheet sheet = workbookPart
                .Workbook
                .Descendants<Sheet>()
                .FirstOrDefault(x => x.Name == SheetValidator.SheetName);

            WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();

            var rows = sheetData.Elements<Row>();

            var rowA1 = rows.FirstOrDefault()
                .Elements<Cell>()
                .First();

            string orderName = _excelValueParser.ParseExcelValue<string>(rowA1, sst);

            var rowsList = rows
                .Skip(3)
                .ToList();
            Order order = new Order()
            {
                Name = orderName
            };

            _logger.Debug("Reading rows...");

            
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
                    string columnName = _excelSheetTools.GetColumnName(cell.CellReference);
                    int cellColumnIndex = (int)_excelSheetTools.GetColumnIndexFromName(columnName);

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
                            content.DocumentNumber = _excelValueParser.ParseExcelValue<string>(cell, sst); //Numer dokumentu
                            break;
                        case 2:
                            content.Name = _excelValueParser.ParseExcelValue<string>(cell, sst); //Nazwa
                            break;
                        case 3:
                            content.Place = new Place()
                            {
                                Name = _excelValueParser.ParseExcelValue<string>(cell, sst)  //Typ
                            };
                            break;
                        case 4:
                            content.PackageQuantity = _excelValueParser.ParseExcelValue<int>(cell, sst);  //Ilość na kpl.
                            break;
                        case 5:
                            content.Material = new Material()
                            {
                                Name = _excelValueParser.ParseExcelValue<string>(cell, sst) //Materiał
                            };
                            break;
                        case 6:
                            content.Thickness = _excelValueParser.ParseExcelValue<decimal?>(cell, sst);   //Grubość
                            break;
                        case 7:
                            content.Width = _excelValueParser.ParseExcelValue<decimal?>(cell, sst);   //Kier. X
                            break;
                        case 8:
                            content.Height = _excelValueParser.ParseExcelValue<decimal?>(cell, sst);  //Kier. Y
                            break;
                        case 9:
                            content.UnitWeight = _excelValueParser.ParseExcelValue<decimal>(cell, sst);  //Masa (jednostkowa)
                            break;
                        case 10:
                            content.ToComplete = _excelValueParser.ParseExcelValue<int>(cell, sst);  //Do realizacji
                            break;
                    }

                    columnIndex++;
                }

                result.Add(content);
            }

            _logger.Debug("Created [{0}] rows", result.Count);
            _logger.Debug("Grouping data...");

            result = GroupData(result);

            return result;
        }

        private List<OrderContent> GroupData(List<OrderContent> list)
        {
            list = (from c in list
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

            return list;
        }
    }
}