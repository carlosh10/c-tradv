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
            return ElasticSearchDAO.ConsultaElasticSearchQtde(paramatro, "ncm");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorNCMValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumValor(paramatro, "ncm");
        }


        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorPaisAquisicaoQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchQtde(paramatro, "paisAquisicao");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorPaisAquisicaoValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumValor(paramatro, "paisAquisicao");
        }


        public static List<AgregationsPorBucketQtde> ConsultaProdutosSensiveisPorPaisOrigemQtde(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchQtde(paramatro, "paisOrigem");
        }
        public static List<AgregationsPorBucketValor> ConsultaProdutosSensiveisPorPaisOrigemValor(string paramatro)
        {
            return ElasticSearchDAO.ConsultaElasticSearchSumValor(paramatro, "paisOrigem");
        }
      
    }
}