using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TradeAdvisor.Models
{
    public class DIDAO
    {
        public static List<DIPOCO> ConsultaDis(string paramatro)
        {
            var node = new Uri("http://146.148.79.38:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var filterQuery = Query<DIPOCO>.Terms("tx_cnpj", paramatro);

            var searchResults = client.Search<DIPOCO>(s => s.Index("doc2").Type("di").Query(filterQuery).Take(20));

            return (List<DIPOCO>)searchResults.Documents;
        }

        public static String ConsultaEmpresaDIPorCnpj(string cnpj)
        {

            using (tfcoreEntities conexao = new tfcoreEntities())
            {

                try
                {
                    var empresa = conexao.tb_di.Where(c => c.tx_cnpj == cnpj).FirstOrDefault();
                    if(empresa != null)
                        return empresa.tx_importadorNome.ToString();
                    return "";
                }
                catch (Exception x)
                {
                    throw new Exception("Erro ao buscar empresa por CNPJ!");
                }
            }
        }
    }
}