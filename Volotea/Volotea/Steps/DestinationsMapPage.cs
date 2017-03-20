using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Steps
{
    public class DestinationsMapPage : BasePage
    {
        private string mapItemXPath = "//p[@id = '***']";
        public string Message { get; private set; }

        public DestinationsMapPage(string browser) : base(browser)
        {
        }

        public DestinationsMapPage(BasePage bp) : base(bp)
        {
        }

        public string CheckCityList(DestinationCityPage page)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in page.cityCodeList)
            {
                string cityOnMapXPath = mapItemXPath.Replace("***", str);
                if (!Driver.FindElement(By.XPath(cityOnMapXPath)).Enabled)
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
