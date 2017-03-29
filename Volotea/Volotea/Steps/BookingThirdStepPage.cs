using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingThirdStepPage
    {
        private IWebDriver driver;
        private string continueAndCustomizeButtonXPath = "//a[@id = 'continueAndCustomizeButton']";

        public BookingThirdStepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BookingForthStepPage ContinueAndCustomize(IWebDriver driver)
        {
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(continueAndCustomizeButtonXPath));
            return new BookingForthStepPage(driver);
        }
    }
}