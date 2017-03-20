using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Volotea.Utils
{
    class XmlDataWorker
    {
        public static void WriteCitiesToXml(List<string> list, string file)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
        public static List<string> GetCitiesFromXml(string file)
        {
            List<string> list;
            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                list = (List<string>)formatter.Deserialize(fs);
            }
            return list;
        }
    }
}
