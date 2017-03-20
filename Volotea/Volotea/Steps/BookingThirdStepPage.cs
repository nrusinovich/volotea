using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingThirdStepPage : BasePage
    {
        private string continueAndCustomizeButtonXPath = "//a[@id = 'continueAndCustomizeButton']";

        public BookingThirdStepPage(BasePage bp) : base(bp)
        {
        }

        public BookingForthStepPage ContinueAndCustomize(BasePage bp)
        {
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(continueAndCustomizeButtonXPath));
            return new BookingForthStepPage(bp);
        }
    }
}