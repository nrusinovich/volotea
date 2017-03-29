using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingSecondStepPage
    {
        private IWebDriver driver;
        private string conditionsOfCarriageXPath = "//input[@name = 'accept']";
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";

        public BookingSecondStepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BookingThirdStepPage NextStep(IWebDriver driver)
        {
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(conditionsOfCarriageXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(nextStepButtonXPath));
            return new BookingThirdStepPage(driver);
        }
    }
}