using OpenQA.Selenium;

namespace ATWithBDDFrameworksSpecflow.PageObjects
{
    public class TitledPageObject
    {
        private readonly IWebDriver _driver;
        private readonly By _titleBy = By.TagName("h1");

        public TitledPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string? Title
        {
            get
            {
                return _driver.FindElementWithWait(_titleBy)?.Text;
            }
        }
    }
}
