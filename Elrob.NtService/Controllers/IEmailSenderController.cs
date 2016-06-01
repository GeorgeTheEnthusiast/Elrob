namespace Elrob.NtService.Controllers
{
    public interface IEmailSenderController
    {
        void SendEmail(string message, string subject);
    }
}
