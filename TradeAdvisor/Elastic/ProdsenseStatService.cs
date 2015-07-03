using System.Net;
using TradeAdvisor.Elastic.Models.Response;

namespace TradeAdvisor.Elastic
{

    class ProdsenseStatService : ElasticSearchService
    {

        public ProdsenseStatService(string indexTypeUri)
        {
            IndexTypeUri = indexTypeUri;
        }

        public string IndexTypeUri { get; set; }

        public DescricaoDetalhadaProdutoResponse SearchByDescricaoDetalhadaProduto(string json_request)
        {
            this.Headers[HttpRequestHeader.ContentType] = "application/json";
            var json_result = this.UploadString(this.IndexTypeUri, "POST", json_request);
            return DescricaoDetalhadaProdutoResponse.Parse(json_result);
        }

    }

}