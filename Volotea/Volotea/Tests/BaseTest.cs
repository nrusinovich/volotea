using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Volotea.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected dynamic page;

        [OneTimeTearDown]
        protected void TearDown()
        {
            page.Quit();
        }
    }
}
