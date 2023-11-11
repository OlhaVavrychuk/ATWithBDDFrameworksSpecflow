using ATWithBDDFrameworksSpecflow.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ATWithBDDFrameworksSpecflow
{
    [Binding]
    public class SearchWorksForInstallationStepDefinitions
    {
        private readonly BrowserDriver _driver;
        private SpecFlowDocumentationPageObject _specFlowDocumentationPage;
        private TitledPageObject _titledPage;

        public SearchWorksForInstallationStepDefinitions(BrowserDriver driver, ScenarioContext context)
        {
            this._driver = driver;
        }

        [Given(@"I opened Docs page for the SpecFlow on the specflow`s site")]
        public void GivenIOpenedDocsPageForTheSpecFlowOnTheSpecflowSSite()
        {
            _driver.Current.Manage().Window.Maximize();
            var _homePage = new HomePageObject(_driver.Current);
            _homePage.Navigate("https://specflow.org/");
            _specFlowDocumentationPage = _homePage.OpenSpecFlowDocumentationPage();
        }

        [When(@"I Search for the '([^']*)'")]
        public void WhenSearchForThe(string searchTerm)
        {
            var _searchResultsPage = _specFlowDocumentationPage.Search(searchTerm);
            _titledPage = _searchResultsPage.SelectFirstResult();
        }

        [Then(@"The page opened has title '([^']*)'")]
        public void ThenThePageOpenedHasTitle(string title)
        {
            Assert.That(_titledPage.Title, Is.EqualTo(title).IgnoreCase);
        }
    }
}
