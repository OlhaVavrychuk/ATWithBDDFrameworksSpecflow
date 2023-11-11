using OpenQA.Selenium;

namespace ATWithBDDFrameworksSpecflow.PageObjects
{
    public class SearchResultsPageObject
    {
        private readonly IWebDriver _driver;
        private readonly By _firstSearchResultLinkBy = By.CssSelector(".search a");

        public SearchResultsPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public TitledPageObject SelectFirstResult()
        {
            var firtsResultLink = _driver.FindElementWithWait(_firstSearchResultLinkBy);
            firtsResultLink?.Click();
            return new TitledPageObject(_driver);
        }
    }
}
