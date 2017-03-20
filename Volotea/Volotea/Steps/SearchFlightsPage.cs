using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Volotea.Steps
{
    public class SearchFlightsPage : BasePage
    {
        private By fromDestinationLocator = By.XPath("//span[@class='predictorLabeler']");

        public SearchFlightsPage(string browser) : base(browser)
        {
        }

        public IWebElement FromDestinationElement
        {
            get { return Driver.FindElement(fromDestinationLocator); }
        }

        public string GetCity()
        {
            return FromDestinationElement.Text;
        }

    }
}
