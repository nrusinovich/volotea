using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class MainPage : BasePage
    {
        private string depAirportXPath = "//input[@placeholder = 'Please choose departure airport']";
        private string depXPath = "//a[contains(text(), 'SXB')]";
        private string desAirportXPath = "//input[@placeholder = 'Please choose destination airport']";
        private string desXPath = "//a[contains(text(), 'NCE')]";
        private string findFlightsXPath = "//a[contains(text(), 'FIND FLIGHTS')]";

        public MainPage(BasePage bp) : base(bp)
        {
        }

        public BookingFirstStepPage SelectFlight(BasePage bp)
        {
            bp.Refresh();
            WebElementHelper.WaitAndClick(Driver, By.XPath(depAirportXPath));
            WebElementHelper.WaitAndClick(Driver, By.XPath(depXPath));
            WebElementHelper.WaitAndClick(Driver, By.XPath(desAirportXPath));
            WebElementHelper.WaitAndClick(Driver, By.XPath(desXPath));
            WebElementHelper.WaitAndClick(Driver, By.XPath(findFlightsXPath));
            return new BookingFirstStepPage(bp);
        }
    }
}
