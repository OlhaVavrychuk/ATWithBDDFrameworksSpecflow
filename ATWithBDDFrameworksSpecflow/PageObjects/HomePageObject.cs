using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ATWithBDDFrameworksSpecflow.PageObjects
{
    public class HomePageObject
    {
        private readonly IWebDriver _driver;

        private readonly By _DocsLinkBy = By.LinkText("Docs");
        private readonly By _SpecFlowLinkBy = By.LinkText("SpecFlow");

        public HomePageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public SpecFlowDocumentationPageObject OpenSpecFlowDocumentationPage()
        {
            var docsLink = _driver.FindElementWithWait(_DocsLinkBy);

            new Actions(_driver)
                .MoveToElement(docsLink)
                .Perform();

            var specFlowLink = _driver.FindElementWithWait(_SpecFlowLinkBy);
            specFlowLink?.Click();

            return new SpecFlowDocumentationPageObject(_driver);
        }
    }
}
