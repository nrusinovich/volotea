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
    public class BookingFirstStepPage
    {
        private IWebDriver driver;
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";

        public BookingFirstStepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BookingSecondStepPage NextStep(IWebDriver driver)
        {
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(nextStepButtonXPath));
            return new BookingSecondStepPage(driver);
        }
    }
}
