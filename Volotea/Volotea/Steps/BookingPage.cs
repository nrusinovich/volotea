using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Volotea.Data;
using System.Threading;

namespace Volotea.Steps
{
    class BookingPage : BasePage
    {
        IWebElement Origin { get; set; }
        IWebElement Destination { get; set; }
        public BookingPage(string browser) : base(browser)
        {

        }
        public void SetFlight(string orig, string destin)
        {
            GoTo($"http://www.volotea.com/en/flight-offers/{orig}/{destin}/");
        }
        public void ChooseDate()
        {
          //  var list = Driver.FindElement(By.XPath("//li[@data-price]"));
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            Thread.Sleep(1000);
            // var clickableElement = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='radio-wrapper']/parent::*")));
            Driver.FindElement(By.XPath("//div[contains(@style, 'block')]//div[@class='radio-wrapper']/parent::*")).Click();
        }
        public void ChooseTripType()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='OneWay']/parent::*")));
            Driver.FindElement(By.XPath("//input[@value='OneWay']/parent::*")).Click();
        }
        public double GetPrice(int i)
        {
            double price;
            WaitUntilDisplayed(Driver.FindElement(By.XPath("//span[@data-type='totalPriceInt']")));
            price = Double.Parse(Driver.FindElement(By.XPath("//span[@data-type='totalPriceInt']")).Text.Substring(1));
            price+= Double.Parse($"0{Driver.FindElement(By.XPath("//sup[@data-type='totalPriceSup']")).Text}");
            return price/i;
        }
        public void ChangePassengerNumber(int k)
        {
            Driver.FindElement(By.XPath($"//a[@ng-click='vm.setModel({k-1})']")).Click();
        }


    }

}
