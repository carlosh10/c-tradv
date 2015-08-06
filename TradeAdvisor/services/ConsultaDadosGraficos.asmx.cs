using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TradeAdvisor.Models;

namespace TradeAdvisor.services
{
    /// <summary>
    /// Summary description for ConsultaDadosGraficos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    
    [System.Web.Script.Services.ScriptService]
    public class ConsultaDadosGraficos : System.Web.Services.WebService
    {

        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorNcmQtde(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorNCMQtde(descricao);
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorNcmValor(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorNCMValor(descricao);
        }


        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorPaisAquisicaoQtde(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisAquisicaoQtde(descricao);
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorPaisAquisicaoValor(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisAquisicaoValor(descricao);
        }


        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorPaisOrigemQtde(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisOrigemQtde(descricao);
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorPaisOrigemValor(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisOrigemValor(descricao);
        }


        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorMesAnoQtde(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorMesAnoQtde(descricao);
        }



        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosDIQtde(string descricao)
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaDIQtde(descricao);
        }
    }
}
