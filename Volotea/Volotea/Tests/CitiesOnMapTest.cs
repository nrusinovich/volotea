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
    public class CitiesOnMapTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            page = new Steps.DestinationCityPage("chrome");
        }

        [Test]
        public void CitiesOnMapCheck()
        {
            page.GetCitiesCodeList();
            DestinationsMapPage destMapPage = page.GoToMapPage(page);
            Assert.IsNull(destMapPage.CheckCityList(page), destMapPage.Message);
        }
    }
}
