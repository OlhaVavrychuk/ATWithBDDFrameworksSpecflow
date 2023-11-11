using BoDi;
using TechTalk.SpecFlow;

namespace ATWithBDDFrameworksSpecflow.Hooks
{

    [Binding]
    public class DriverSupportForScenario
    {
        private readonly IObjectContainer objectContainer;

        public DriverSupportForScenario(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void AddWebDriver()
        {
            var config = ConfigurationSupportForTestRun.Configuration;
            var driver = new BrowserDriver(config);
            //var driver = new BrowserDriver(config).Current;
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]

        public void DisposeWebDriver()
        {
            var driver = objectContainer.Resolve<BrowserDriver>();
            driver.Dispose();
        }
    }
}
