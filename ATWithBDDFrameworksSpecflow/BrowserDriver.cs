using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ATWithBDDFrameworksSpecflow
{
    public sealed class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _driver;
        private bool _disposed;

        public BrowserDriver(IConfiguration configuration)
        {
            _driver = new Lazy<IWebDriver>(GetDriver);
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        private IWebDriver GetDriver()
        {
            var browser = _configuration["browser"];
            switch (browser?.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver();
                default:
                    throw new InvalidOperationException($"Not supported browser: {browser}");
            }
        }

        public IWebDriver Current => _driver.Value;

        public void Dispose()
        {
            if(_disposed ) return;

            if(_driver.IsValueCreated)
            {
                Current.Quit();
            }

            _disposed = true;
        }
    }

}
