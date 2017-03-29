using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class DestinationCityPage : BasePage
    {
        private string mainPageUrl = "http://www.volotea.com/en";
        private string mapUrl = "http://www.volotea.com/en/destinations/";
        private string citiesTableXPath = "//input[@placeholder = 'Please choose departure airport']";
        private string cityXPath = "//div[contains(@class, 'col-sm-3')][..//li]";
        string pattern = "[A-Z]{3}";
        public List<string> cityCodeList { get; private set; }

        public DestinationCityPage(string browser) : base(browser)
        {
        }

        public void GetCitiesCodeList()
        {
            Driver.Navigate().GoToUrl(mainPageUrl);
            WebElementHelper.WaitAndClick(Driver, By.XPath(citiesTableXPath));

            var tmpList = Driver.FindElements(By.XPath(cityXPath));

            List<string> cityCodeList = new List<string>();
            List<string> draftList = new List<string>();

            foreach (var k in tmpList)
            {
                string[] cityArr = k.Text.Split('\n');
                draftList.AddRange(cityArr);
            }

            foreach (string a in draftList)
            {
                Match m = Regex.Match(a, pattern);
                if (m.Success)
                {
                    cityCodeList.Add(m.Value);
                }
            }
            this.cityCodeList = cityCodeList;
        }

        public DestinationsMapPage GoToMapPage(BasePage bp)
        {
            Driver.Navigate().GoToUrl(mapUrl);
            return new DestinationsMapPage(bp);
        }
    }
}
