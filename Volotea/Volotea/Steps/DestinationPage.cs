using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
namespace Volotea.Steps
{
    class DestinationPage : BasePage
    {
        public DestinationPage(string browser) : base(browser)
        {

        }
       
        public void GoToDestinationsPage()
        {
            Driver.Navigate().GoToUrl(@"http://www.volotea.com/en/inspiration/destinations/");
        }
        public void GoToDestinationsPage(string tag)
        {
            Driver.Navigate().GoToUrl($"http://www.volotea.com/en/inspiration/destinations/tags/{tag}");
        }
        public void GoToCityPage(string name)
        {
            Driver.Navigate().GoToUrl($"http://www.volotea.com/en/inspiration/{name}");
        }
        public List<string> GetAllDestinations() {
            var list = Driver.FindElements(By.ClassName("destination"));
            var lists = list.Select(l => l.Text).ToList();
            return lists;
        }
        public List<string> GetAllTags()
        {
            var list = Driver.FindElements(By.XPath("//a[@data-type = 'tag']"));
            var lists = list.Select(l => l.Text).ToList();
            return lists;
        }
        public void FindCityOnPage(string city)
        {
            var list = Driver.FindElement(By.XPath("//h3[@class = 'destination']"));
        

        }
       
    }
}
