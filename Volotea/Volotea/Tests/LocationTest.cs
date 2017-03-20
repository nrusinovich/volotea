using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework; 

namespace Volotea.Tests
{
    [Ignore("There are few free minutes on BrowserStack. Please, don`t use :3")]
    [TestFixture]
    public class LocationTest : BaseTest
    {
        private Steps.SearchFlightsPage pageBrowserStack;
        private string url;

        [SetUp]
        public void SetUp()
        {
            page = new Steps.SearchFlightsPage("chrome");
            pageBrowserStack = new Steps.SearchFlightsPage("browserstack");
            url = $"{Data.TestData.BaseURL}search-flights/";
        }

        [Test]
        public void TestLocation()
        {
            page.GoTo(url);
            pageBrowserStack.GoTo(url);
            string localCity = page.GetCity();
            string browserStackCity = pageBrowserStack.GetCity();

            Assert.True(localCity.Contains("Chisinau"));
            Assert.True(browserStackCity.Contains("Lille"));
        }

        [TearDown]
        public void Clean()
        {
            pageBrowserStack.Quit();
        }
    }
}
