using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Volotea.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTest1 : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            page = new Steps.LoginElement("chrome");
        }

        [Test]
        public void TestParallelization()
        {
            page.GoTo(Data.TestData.BaseURL);
            page.SignIn(Data.TestData.Login, Data.TestData.Password);
            Assert.AreEqual(page.GetUserSurname(), Data.TestData.Name);
        }
    }
}
