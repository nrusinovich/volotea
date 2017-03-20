using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Volotea.Steps;

using System.IO;
using System.Xml.Serialization;
using Volotea.Utils;
using Volotea.Data;

namespace Volotea.Tests
{
    [TestFixture]
    class Destinations
    {
        public DestinationPage page;
        [OneTimeSetUp]
        public void SetUpAttribute()
        {
            page = new DestinationPage("chrome");
        }
        [Ignore("Already done. Run only to get new cities.")]
        [Test]
        public void GetDestinations()
        {
    
            page.GoToDestinationsPage();
            var list = page.GetAllDestinations();
            XmlDataWorker.WriteCitiesToXml(list, TestData.CitiesXmlFile);
        }
        [OneTimeTearDown]
        public void Clean()
        {
            page.Quit();
        }
    }
}
