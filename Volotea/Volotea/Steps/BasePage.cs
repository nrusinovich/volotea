using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Steps
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(string browser)
        {
            Driver = WebDriver.GetBrowser(browser);
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void MakeNewTab()
        {
            IWebElement link = Driver.FindElement(By.XPath("//a[@id='logo']"));
            Actions newTab = new Actions(Driver);
            newTab.KeyDown(Keys.Control).KeyDown(Keys.Shift).Click(link).KeyUp(Keys.Control).KeyUp(Keys.Shift).Build().Perform();
        }

        public void SwitchToLastTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        protected void WaitUntilDisplayed(IWebElement elem)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(Driver => elem.Displayed);
        }

        protected void WaitAndClick(IWebElement elem)
        {
            WaitUntilDisplayed(elem);
            elem.Click();
        }

        public void MoveCursorToElement(IWebElement elem)
        {            
            Actions builder = new Actions(Driver);
            builder.MoveToElement(elem).Perform();
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
