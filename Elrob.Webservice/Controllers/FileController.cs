namespace Elrob.Webservice.Controllers
{
    using System;
    using System.IO;

    public class FileController : IFileController
    {
        private readonly IConfigurationManager _configurationManager;

        public FileController(IConfigurationManager configurationManager)
        {
            if (configurationManager == null) throw new ArgumentNullException("configurationManager");

            this._configurationManager = configurationManager;
        }

        public string SaveFile(byte[] fileBytes, string fileName)
        {
            fileName = string.Format("{0}_{1}", fileName, DateTime.Now.ToString("yyyyMMdd-HHmmss"));
            string resultFilePath = Path.Combine(this._configurationManager.ExcelOutputDir, fileName);

            if (!Directory.Exists(this._configurationManager.ExcelOutputDir))
            {
                Directory.CreateDirectory(this._configurationManager.ExcelOutputDir);
            }

            using (var stream = new FileStream(resultFilePath, FileMode.Create, FileAccess.Write))
            {
                stream.Write(fileBytes, 0, fileBytes.Length);
            }

            return resultFilePath;
        }
    }
}