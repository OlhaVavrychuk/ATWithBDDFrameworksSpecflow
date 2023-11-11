using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace ATWithBDDFrameworksSpecflow.PageObjects
{
    public class SpecFlowDocumentationPageObject
    {
        private readonly IWebDriver _driver;
        private readonly By _searchFormBy = By.Id("rtd-search-form");
        private readonly By _searchInputBy = By.ClassName("search__outer__input");


        public SpecFlowDocumentationPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public SearchResultsPageObject Search(string searchTerm)
        {
            var searchForm = _driver.FindElementWithWait(_searchFormBy);
            searchForm?.Click();
            var searchInput = _driver.FindElementWithWait(_searchInputBy);
            searchInput?.Clear();
            searchInput?.SendKeys(searchTerm);
            searchInput?.SendKeys(Keys.Enter);

            return new SearchResultsPageObject(_driver);
        }
    }
}
