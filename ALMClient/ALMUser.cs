using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ALMRestClient
{
    public class ALMUser
    {
        public string Name { get; set; }
        public string FullName { get; set; }

        public static ALMUser FromXML(XElement element)
        {
            var user = new ALMUser
            {
                FullName = element.Attribute("FullName").Value,
                Name = element.Attribute("Name").Value
            };


            //foreach (var field in fields)
            //{
            //    var name = field.Attribute("Name").Value;
            //    var valueElement = field.Element("Value");

            //    if (valueElement == null)
            //    {
            //        // skip ones with no values
            //        continue;
            //    }

            //    var value = valueElement.Value;

            //    item.Fields.Add(name, value);
            //}

            return user;
        }
    }
}
