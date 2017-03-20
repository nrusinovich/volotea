using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingSecondStepPage : BasePage
    {
        private string conditionsOfCarriageXPath = "//input[@name = 'accept']";
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";

        public BookingSecondStepPage(BasePage bp) : base(bp)
        {
        }

        public BookingThirdStepPage NextStep(BasePage bp)
        {
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(conditionsOfCarriageXPath));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(nextStepButtonXPath));
            return new BookingThirdStepPage(bp);
        }
    }
}