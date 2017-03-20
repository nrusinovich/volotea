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
    public class MainPage
    {
        private IWebDriver driver;
        private string depAirportXPath = "//input[@placeholder = 'Please choose departure airport']";
        private string depXPath = "//a[contains(text(), 'SXB')]";
        private string desAirportXPath = "//input[@placeholder = 'Please choose destination airport']";
        private string desXPath = "//a[contains(text(), 'NCE')]";
        private string findFlightsXPath = "//a[contains(text(), 'FIND FLIGHTS')]";

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BookingFirstStepPage SelectFlight(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            WebElementHelper.WaitAndClick(driver, By.XPath(depAirportXPath));
            WebElementHelper.WaitAndClick(driver, By.XPath(depXPath));
            WebElementHelper.WaitAndClick(driver, By.XPath(desAirportXPath));
            WebElementHelper.WaitAndClick(driver, By.XPath(desXPath));
            WebElementHelper.WaitAndClick(driver, By.XPath(findFlightsXPath));
            return new BookingFirstStepPage(driver);
        }
    }
}
