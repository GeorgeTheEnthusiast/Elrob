namespace Elrob.Webservice.Controllers
{
    public interface IFileController
    {
        string SaveFile(byte[] fileBytes, string fileName);
    }
}