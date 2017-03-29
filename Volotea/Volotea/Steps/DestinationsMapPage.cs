using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Steps
{
    public class DestinationsMapPage
    {
        private string mapItemXPath = "//p[@id = '***']";
        public string Message { get; private set; }
        private IWebDriver driver;

        public DestinationsMapPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string CheckCityList(DestinationCityPage page)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in page.cityCodeList)
            {
                string cityOnMapXPath = mapItemXPath.Replace("***", str);
                if (!driver.FindElement(By.XPath(cityOnMapXPath)).Enabled)
                {
                    Message = string.Format("city {0} does not found", str);
                    sb.Append(Message);
                }
            }
            this.Message = Message;
            return Message;
        }
    }
}
