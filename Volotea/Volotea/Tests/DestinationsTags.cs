using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Volotea.Steps;
using System.Threading;
using Volotea.Data;
using Volotea.Utils;

namespace Volotea.Tests
{
    [TestFixture]
    class DestinationsTags
    {
        public DestinationPage page = new DestinationPage("chrome");
        [OneTimeSetUp]
        public void SetUpAttribute()
        {
           // page = new DestinationPage("chrome");
            page.GoToDestinationsPage();
        }
        public static List<string> list = XmlDataWorker.GetCitiesFromXml(TestData.CitiesXmlFile);
        [Ignore("Problems with data file path")]
        [Test, TestCaseSource("list")]
        public void CheckDestinationTags(string city)
        {
                page.GoToCityPage(city);
                var tags = page.GetAllTags();
                foreach (var tag in tags)
                {
                    page.GoToDestinationsPage(tag);
                    page.FindCityOnPage(city);
                }
          
        }
        [OneTimeTearDown]
        public void Clean()
        {
            page.Quit();
        }
    }
}
