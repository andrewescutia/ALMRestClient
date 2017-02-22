using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ALMRestClient
{
    public class ALMDomain
    {
        public ALMDomain()
        {
            Projects = new string[0];
        }
        public string Name { get; set; }

        public IEnumerable<string> Projects { get; set; }

        public static ALMDomain FromXML(XElement element)
        {
            return new ALMDomain()
            {
                Name = element.Attribute("Name").Value,
                Projects = element.Element("Projects").Elements("Project").Select(e => e.Attribute("Name").Value)
            };
        }
    }

}
