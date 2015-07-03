using System.Net;

namespace TradeAdvisor.Elastic
{

    class ElasticSearchService : WebClient
    {

        public static ProdsenseStatService ProdsenseStat
        {
            get
            {
                return new ProdsenseStatService(ElasticSearchIndexTypeUri(ElasticSearchIndexType.ProdsenseStat));
            }
        }

        private static string ElasticSearchIndexTypeUri(ElasticSearchIndexType elasticSearchIndexType)
        {
            switch (elasticSearchIndexType)
            {
                case ElasticSearchIndexType.ProdsenseStat:
                    return "http://146.148.79.38:9400/prodsense/stat/_search";

                default:
                    return string.Empty;
            }
        }

    }

    public enum ElasticSearchIndexType
    {
        ProdsenseStat
    }
    
}