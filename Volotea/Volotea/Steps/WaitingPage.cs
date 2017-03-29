using OpenQA.Selenium;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class WaitingPage
    {
        private IWebDriver driver;
        private string paymentMessageXPath = "//h1[contains(text(), 'THANK YOU FOR YOUR PATIENCE')]";

        public WaitingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsPaymentPass(IWebDriver driver)
        {
            if (driver.FindElement(By.XPath(paymentMessageXPath)).Displayed)
            {
                return true;
            }
            return false;
        }
    }
}