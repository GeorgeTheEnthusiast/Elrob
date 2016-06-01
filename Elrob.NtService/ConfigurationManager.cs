namespace Elrob.NtService
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string DailyReportRecipient => System.Configuration.ConfigurationManager.AppSettings["dailyReportRecipient"];
    }
}