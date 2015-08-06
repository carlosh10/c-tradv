using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TradeAdvisor.Models
{
    public class PRODUTO_SENSIVEIS_DAO
    {

        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorNCMQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchProdSenseQtde(paramatro, "ncm");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorNCMValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumProdSenseValor(paramatro, "ncm");
        }


        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorPaisAquisicaoQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchProdSenseQtde(paramatro, "paisAquisicao");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorPaisAquisicaoValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumProdSenseValor(paramatro, "paisAquisicao");
        }


        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorPaisOrigemQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchProdSenseQtde(paramatro, "paisOrigem");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorPaisOrigemValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumProdSenseValor(paramatro, "paisOrigem");
        }


        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorMesAnoQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchProdSenseQtde(paramatro, "mes_ano");
        }

        public static List<AgregationsPorBucketQtde> ConsultaDIQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchCountDocumentos(paramatro);
        }
    }
}