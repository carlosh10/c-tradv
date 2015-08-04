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
        public List<AgregationsPorBucketQtde> ConsultaDadosPorNcmQtde()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorNCMQtde("iphone");
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorNcmValor()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorNCMValor("iphone");
        }


        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorPaisAquisicaoQtde()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisAquisicaoQtde("iphone");
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorPaisAquisicaoValor()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisAquisicaoValor("iphone");
        }


        [WebMethod]
        public List<AgregationsPorBucketQtde> ConsultaDadosPorPaisOrigemQtde()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisOrigemQtde("iphone");
        }
        [WebMethod]
        public List<AgregationsPorBucketValor> ConsultaDadosPorPaisOrigemValor()
        {
            return PRODUTO_SENSIVEIS_DAO.ConsultaProdutosSensiveisPorPaisOrigemValor("iphone");
        }
    }
}
