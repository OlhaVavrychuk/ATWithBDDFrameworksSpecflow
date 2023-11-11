using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace ATWithBDDFrameworksSpecflow.Hooks
{
    [Binding]
    public static class ConfigurationSupportForTestRun
    {
        private static IConfiguration _configuration;
        public static IConfiguration Configuration => _configuration;

        [BeforeTestRun]
        public static void AddConfigurationBeforeTestRun()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build(); 
        }
    }
}
