using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ATWithBDDFrameworksSpecflow
{
    public static class DriverHelper
    {
        public static IWebElement? FindElementWithWait(this IWebDriver driver, By by)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(d =>
                {
                    var element = d.FindElement(by);
                    return element.Displayed && element.Enabled ? element : null;
                });

        }
    }
}
