using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestSharp;

namespace ALMRestClient
{
    public class ALMDomainManager : ALMClient
    {

        public ALMDomainManager(string url, string username, string password):
            base(url, username, password, string.Empty, string.Empty)
        {
        }

        public IEnumerable<ALMDomain> GetDomains()
        {
            RestRequest getDomains = new RestRequest(clientConfig.DomainsAddress);
            getDomains.AddQueryParameter("include-projects-info", "y");
            getDomains.AddHeader("Accept", "application/xml");

            IRestResponse response = Execute(getDomains, "get domains");

            var doc = XDocument.Parse(response.Content);

            var domains = doc.Root.Nodes()
                .Select(n => ALMDomain.FromXML(n as XElement));
            return domains;
        }
    }
}
