using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Elrob.Webservice.Exceptions;

namespace Elrob.Webservice.Controlers
{
    public class FileController : IFileController
    {
        private readonly IConfigurationManager _configurationManager;

        public FileController(IConfigurationManager configurationManager)
        {
            if (configurationManager == null) throw new ArgumentNullException("configurationManager");

            _configurationManager = configurationManager;
        }

        public string SaveFile(byte[] fileBytes, string fileName)
        {
            string resultFilePath = Path.Combine(_configurationManager.ExcelOutputDir, fileName);

            if (!Directory.Exists(_configurationManager.ExcelOutputDir))
            {
                Directory.CreateDirectory(_configurationManager.ExcelOutputDir);
            }

            if (File.Exists(resultFilePath))
            {
                throw new FaultException<FileWithThatNameAlreadyExistException>(new FileWithThatNameAlreadyExistException(resultFilePath));
            }

            using (var stream = new FileStream(resultFilePath, FileMode.Create, FileAccess.Write))
            {
                stream.Write(fileBytes, 0, fileBytes.Length);
            }

            return resultFilePath;
        }
    }
}