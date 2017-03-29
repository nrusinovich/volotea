using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volotea.Steps;

namespace Volotea.Tests
{
    [TestFixture]
    public class CitiesOnMapTest
    {
        public DestinationCityPage destCityPage;
        public DestinationsMapPage destMapPage;
        public IWebDriver driver = WebDriver.GetBrowser("chrome");

        [SetUp]
        public void SetUp()
        {
            destCityPage = new DestinationCityPage(driver);
        }

        [Test]
        public void CitiesOnMapCheck()
        {
            destCityPage.GetCitiesCodeList(driver);

            destMapPage = destCityPage.GoToMapPage();

            Assert.IsNull(destMapPage.CheckCityList(destCityPage), destMapPage.Message);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
