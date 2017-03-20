using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Volotea.Steps;

namespace Volotea.Tests
{
    [TestFixture]
    class BookingTest
    {
        public BookingPage page;
        public static List<Tuple<string, string>> list = new List<Tuple<string, string>> { new Tuple<string, string>("palermo", "nantes") , new Tuple<string, string>("vienna","marseille"), new Tuple<string, string>("lille", "bastia") };
        [OneTimeSetUp]
        public void SetUpAttribute()
        {
            page = new BookingPage("chrome");
        }
        [Test, TestCaseSource("list")]
        public void PriceTest(Tuple<string,string> city)
        {
            page.SetFlight(city.Item1, city.Item2);
            page.ChooseTripType();                          // set one way trips
            page.ChooseDate();                              // choose first available date
            var t = page.GetPrice(1); 
            page.ChangePassengerNumber(2);
            var t1 = page.GetPrice(2);
            Assert.AreEqual(t, t1, 0.01);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            page.Quit();
        }
    }
}
