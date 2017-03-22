using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Utils
{
    public static class WebElementHelper
    {
        public static IWebElement WaitUntilElementVisible(IWebDriver Driver, By locator)
        {
            //IWebElement element = Driver.FindElement(locator);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return Driver.FindElement(locator);
        }

        public static void WaitAndClick(IWebDriver Driver, By locator)
        {
            WaitUntilElementVisible(Driver, locator).Click();
        }

        public static void WaitAndSendKeys(IWebDriver Driver, By locator, string str)
        {
            WaitUntilElementVisible(Driver, locator).SendKeys(str);
        }

        public static void MoveToElementAndClick(IWebDriver Driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(locator));
            Actions act = new Actions(Driver);
            act.MoveToElement(Driver.FindElement(locator)).Click().Build().Perform();
        }
        /*
        public static void WaitJS(IWebDriver Driver)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until();
        }*/
    }
}
