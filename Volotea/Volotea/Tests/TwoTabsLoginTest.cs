using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Volotea.Tests
{
    [TestFixture]
    public class TwoTabsLoginTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            page = new Steps.LoginElement("chrome");
        }

        [Test]
        public void TestTwoTabsLogin()
        {
            page.GoTo(Data.TestData.BaseURL);
            page.MakeNewTab();
            page.SignIn(Data.TestData.Login, Data.TestData.Password);
            page.SwitchToLastTab();
            page.Refresh();
            Assert.AreEqual(page.GetUserSurname(), Data.TestData.Name);
        }
    }
}