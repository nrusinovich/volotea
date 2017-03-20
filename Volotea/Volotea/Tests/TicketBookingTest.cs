using NUnit.Framework;
using System.Threading;
using Volotea.Steps;

namespace Volotea.Tests
{
    [TestFixture]
    public class TicketBookingTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            page = new Steps.LoginElement("chrome");
        }

        [Test]
        public void TicketBookingCheck()
        {
            page.GoTo(Data.TestData.BaseURL);
            MainPage mp = page.SignIn(page, Data.TestData.Login, Data.TestData.Password);
            BookingFirstStepPage bfsp = mp.SelectFlight(mp);
            BookingSecondStepPage bssp = bfsp.NextStep(bfsp);
            BookingThirdStepPage btsp = bssp.NextStep(bssp);
            BookingForthStepPage bForthSP = btsp.ContinueAndCustomize(btsp);
            PaymentStepPage psp = bForthSP.NextStep(bForthSP);
            WaitingPage wp = psp.BookThisFlight(psp);
            Assert.True(wp.IsPaymentPass(wp));
        }
    }
}
