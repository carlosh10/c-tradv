using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class DIDAO
    {
        public static List<DIPOCO> ConsultaDis()
        {
            var node = new Uri("http://146.148.79.38:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var searchResults = client.Search<DIPOCO>(s => s.Index("doc2").Type("di").Take(10));

            return (List<DIPOCO>)searchResults.Documents;
        }
    }
}