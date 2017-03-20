using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace Volotea.Tests
{
    [TestFixture]
    class HotelsTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            page = new Steps.HotelsPage("chrome");            
        }

        [Test]
        public void TestCheapestHotel()
        {
            page.GoTo("http://hotels.volotea.com/");
            Thread.Sleep(1000);
            page.FindHotels();
            Thread.Sleep(15000);
            page.FindCheapestHotelAndGo();
            string expectedPrice = page.LowestPrice;
            Thread.Sleep(15000);
            Assert.AreEqual(expectedPrice, page.GetActualPrice());
        }
    }
}
