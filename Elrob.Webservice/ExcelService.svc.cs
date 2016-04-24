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
    using Elrob.Webservice.Validators;

    using Ninject;

    public class ExcelService : IExcelService
    {
        private readonly IFileController _fileController;
        
        private readonly ISheetValidator _sheetValidator;

        private readonly IExcelRowsReader _excelRowsReader;

        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        public string SheetName { get; } = "Arkusz2";

        public ExcelService() : this(
            Global.Kernel.Get<IFileController>(),
            Global.Kernel.Get<ISheetValidator>(),
            Global.Kernel.Get<IExcelRowsReader>()
            )
        {
            
        }

        public ExcelService(
            IFileController fileController, 
            ISheetValidator sheetValidator,
            IExcelRowsReader excelRowsReader)
        {
            if (fileController == null) throw new ArgumentNullException("fileController");
            if (sheetValidator == null)
            {
                throw new ArgumentNullException(nameof(sheetValidator));
            }
            if (excelRowsReader == null)
            {
                throw new ArgumentNullException(nameof(excelRowsReader));
            }

            _fileController = fileController;
            this._sheetValidator = sheetValidator;
            this._excelRowsReader = excelRowsReader;
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

            try
            {
                string filePath = _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName);

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                    {
                        var sheetIsCorrect = _sheetValidator.Validate(doc);

                        if (!sheetIsCorrect)
                        {
                            response.ResponseMessage = _sheetValidator.ValidationMessage;
                            return response;
                        }

                        response.OrderContents = _excelRowsReader.ReadRows(doc);
                    }
                }

                _logger.Debug("Import of excel data completed successfully");
            }
            catch (Exception ex)
            {
                response.ResponseMessage =
                    "Wystąpił błąd podczas importu danych na serwerze. Skontaktuj się z administratorem.";
                _logger.Error(ex);
            }

            return response;
        }
    }
}
