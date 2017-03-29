using OpenQA.Selenium;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class PaymentStepPage
    {
        private IWebDriver driver;
        private string flexWindowXPath = "//a[@id = 'closeFlexLink']";
        private string cvvXPath = "//input[@id = 'cvv1']";
        private string cvv = "123";
        private string bookThisFlightButtonXPath = "//a[@id = 'ControlGroupPaymentNewBottom_LinkButtonSubmit']";

        public PaymentStepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WaitingPage BookThisFlight(IWebDriver driver)
        {
            WebElementHelper.WaitAndClick(driver, By.XPath(flexWindowXPath));
            WebElementHelper.WaitAndSendKeys(driver, By.XPath(cvvXPath), cvv);
            WebElementHelper.WaitAndClick(driver, By.XPath(bookThisFlightButtonXPath));
            return new WaitingPage(driver);
        }
    }
}