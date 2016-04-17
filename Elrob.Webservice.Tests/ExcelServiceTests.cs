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
    [TestFixture]
    public class ExcelServiceTests
    {
        private IExcelService _sut;
        private IFileController _fileController;

        [SetUp]
        public void SetUp()
        {
            _fileController = Substitute.For<IFileController>();
            _sut = new ExcelService(_fileController);
        }

        [Test]
        public void ImportExcelFileGeneratesValidOutput()
        {
            ImportDataRequest importDataRequest = new ImportDataRequest()
            {
                FileBytes = new byte[0],
                FileName = "excelFile.xlsx"
            };
            int i = 0;

            _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName).Returns(@"..\..\docs\Zamówienie nr 55.xlsx");

            var response = _sut.ImportData(importDataRequest);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.OrderContents, Is.Not.Null);
            Assert.That(response.OrderContents.Count, Is.GreaterThan(0));
        }

        [Test]
        public void WorkbookWithoutRequiredSheetReturnsEmptyResult()
        {
            ImportDataRequest importDataRequest = new ImportDataRequest()
            {
                FileBytes = new byte[0],
                FileName = "excelFile.xlsx"
            };
            string uniqueText = Guid.NewGuid().ToString();
            var returnList = new List<OrderContent>();

            _fileController.SaveFile(importDataRequest.FileBytes, importDataRequest.FileName).Returns(@"..\..\docs\Zamówienie nr 55.xlsx");
            _sut.SheetName.Returns(uniqueText);

            Assert.That(_sut.ImportData(importDataRequest).OrderContents, Is.EqualTo(returnList));
        }
    }
}
