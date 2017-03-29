using OpenQA.Selenium;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class WaitingPage : BasePage
    {
        private string paymentMessageXPath = "//h1[contains(text(), 'THANK YOU FOR YOUR PATIENCE')]";

        public WaitingPage(BasePage bp) : base(bp)
        {
        }

        public bool IsPaymentPass(BasePage bp)
        {
            if (Driver.FindElement(By.XPath(paymentMessageXPath)).Displayed)
            {
                return true;
            }
            return false;
        }
    }
}