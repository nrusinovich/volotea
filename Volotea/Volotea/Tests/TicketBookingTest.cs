using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Steps;

namespace Volotea.Tests
{
    [TestFixture]
    public class TicketBookingTest
    {
        public IWebDriver driver = WebDriver.GetBrowser("chrome");

        [Test]
        public void TicketBookingCheck()
        {
            driver.Manage().Window.Maximize();
            LoginPage lp = new LoginPage(driver);
            MainPage mp = lp.LogiIn(driver);
            BookingFirstStepPage bfsp = mp.SelectFlight(driver);
            BookingSecondStepPage bssp = bfsp.NextStep(driver);
            BookingThirdStepPage btsp = bssp.NextStep(driver);
            BookingForthStepPage bForthSP = btsp.ContinueAndCustomize(driver);
            PaymentStepPage psp = bForthSP.NextStep(driver);
            WaitingPage wp = psp.BookThisFlight(driver);
            Assert.True(wp.IsPaymentPass(driver));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
