using System;
using System.Collections.Generic;
using System.IO;
using Elrob.Webservice.Controlers;
using Elrob.Webservice.Dto;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Elrob.Webservice.Tests
{
    using System.Reflection;

    using DocumentFormat.OpenXml.Packaging;

    using Elrob.Webservice.Validators;

    using Ninject;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class ExcelServiceTests
    {
        private IExcelService _sut;
        private IFileController _fileController;
        private ISheetValidator _sheetValidator;
        private IExcelRowsReader _excelRowsReader;

        [SetUp]
        public void SetUp()
        {
            _fileController = Substitute.For<IFileController>();
            _sheetValidator = Substitute.For<ISheetValidator>();
            _excelRowsReader = Substitute.For<IExcelRowsReader>();
            _sut = new ExcelService(_fileController, _sheetValidator, _excelRowsReader);
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.ImportData(null));
        }

        [Test]
        public void ImportExcelFileGeneratesValidOutput()
        {
            ImportDataRequest importDataRequest = new ImportDataRequest()
            {
                FileBytes = new byte[0],
                FileName = "excelFile.xlsx"
            };
            var fixture = new Fixture();
            var resultList = fixture.Create<List<OrderContent>>();

            _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName).Returns(@"..\..\docs\Zamówienie nr 55.xlsx");
            _sheetValidator.Validate(Arg.Any<SpreadsheetDocument>()).Returns(true);
            _excelRowsReader.ReadRows(Arg.Any<SpreadsheetDocument>()).Returns(resultList);

            var response = _sut.ImportData(importDataRequest);

            Assert.That(response.ResponseMessage, Is.Null.Or.Empty);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.OrderContents, Is.Not.Null);
            Assert.That(response.OrderContents.Count, Is.GreaterThan(0));
        }

        [Test]
        public void InvalidSheetWillCauseEmptyResponse()
        {
            ImportDataRequest importDataRequest = new ImportDataRequest()
            {
                FileBytes = new byte[0],
                FileName = "excelFile.xlsx"
            };
            var fixture = new Fixture();
            var validationMessage = fixture.Create<string>();

            _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName).Returns(@"..\..\docs\Zamówienie nr 55.xlsx");
            _sheetValidator.Validate(Arg.Any<SpreadsheetDocument>()).Returns(false);
            _sheetValidator.ValidationMessage.Returns(validationMessage);

            var response = _sut.ImportData(importDataRequest);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseMessage, Is.EqualTo(validationMessage));
            Assert.That(response.OrderContents, Is.Not.Null);
            Assert.That(response.OrderContents.Count, Is.EqualTo(0));
        }
    }
}
