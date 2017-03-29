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
        public static IWebElement WaitUntilElementVisible(IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public static void WaitAndClick(IWebDriver driver, By locator)
        {
            WaitUntilElementVisible(driver, locator).Click();
        }

        public static void WaitAndSendKeys(IWebDriver driver, By locator, string str)
        {
            WaitUntilElementVisible(driver, locator).SendKeys(str);
        }

        public static void MoveToElementAndClick(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(locator));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(locator)).Click();
            act.Perform();
        }
    }
}
