using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingFirstStepPage : BasePage
    {
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";

        public BookingFirstStepPage(BasePage bp) : base(bp)
        {
        }

        public BookingSecondStepPage NextStep(BasePage bp)
        {
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(nextStepButtonXPath));
            return new BookingSecondStepPage(bp);
        }
    }
}
