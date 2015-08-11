using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class CEDAO
    {
        public static List<CE_POCO> ConsultaDis(string paramatro)
        {
            var node = new Uri("http://146.148.79.38:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var filterQuery = Query<CE_POCO>.Terms("tx_cnpj", paramatro);

            var searchResults = client.Search<CE_POCO>(s => s.Index("doc2").Type("ce").Query(filterQuery).Take(20));

            return (List<CE_POCO>)searchResults.Documents;

        }
        public static String ConsultaEmpresaCEPorCnpj(string cnpj)
        {

            using (mercanteEntities conexao = new mercanteEntities())
            {

                try
                {
                    var empresa = conexao.tb_ce_mercante.Where(c => c.cdconsignatario == cnpj).FirstOrDefault();
                    if (empresa != null)
                        return empresa.nmconsignatario.ToString();
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