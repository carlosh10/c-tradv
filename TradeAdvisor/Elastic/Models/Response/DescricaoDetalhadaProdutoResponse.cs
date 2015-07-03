using Newtonsoft.Json;
using System.Collections.Generic;

namespace TradeAdvisor.Elastic.Models.Response
{

    public class DescricaoDetalhadaProdutoResponse
    {

        public int took { get; set; }
        public bool timed_out { get; set; }
        public DescricaoDetalhadaProdutoHitsResponse hits { get; set; }

        public static DescricaoDetalhadaProdutoResponse Parse(string json)
        {
            return JsonConvert.DeserializeObject<DescricaoDetalhadaProdutoResponse>(json);
        }

    }

    public class DescricaoDetalhadaProdutoHitsResponse
    {

        public List<DescricaoDetalhadaProdutoHitsHitsResponse> hits { get; set; }

    }

    public class DescricaoDetalhadaProdutoHitsHitsResponse
    {

        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public string _score { get; set; }
        public DescricaoDetalhadaProdutoHitsHitsSourceResponse _source { get; set; }

    }

    public class DescricaoDetalhadaProdutoHitsHitsSourceResponse
    {

        public string nr_ordem { get; set; }
        public string id_mes_ano { get; set; }
        public string mes_ano { get; set; }
        public string ncm { get; set; }
        public string descricao_ncm { get; set; }
        public string codigo_pais_origem { get; set; }
        public string pais_origem { get; set; }
        public string codigo_pais_aquisicao { get; set; }
        public string pais_aquisicao { get; set; }
        public string codigo_unidade_medida_estatistica { get; set; }
        public string unidade_medida_estatistica { get; set; }
        public string unidade_comercializacao { get; set; }
        public string descricao_detalhada_produto { get; set; }
        public string quantidade_estatistica { get; set; }
        public string peso_liquido_kg { get; set; }
        public string valor_fob_dolar { get; set; }
        public string valor_frete_dolar { get; set; }
        public string valor_seguro_dolar { get; set; }
        public string valor_unidade_produto_dolar { get; set; }
        public string quantidade_comercializada_produto { get; set; }
        public string valor_total_produto_dolar { get; set; }
        public string data_ordem { get; set; }
        public string pk_ncmrf_14a { get; set; }

    }

}