using Elasticsearch.Net;
using Elasticsearch.Net.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TradeAdvisor.Models
{
    public class NcmDAO
    {
        public class ResumoConsulta
        {
            public string tx_ncm_desc { get; set; }
            public string ncm { get; set; }
            public int? vl_ift { get; set; }
            public int countReg { get; set; }
            public float CIFTot { get; set; }

            public string descricao_detalhada_produto { get; set; }
        }
        //public static List<vw_ncm_full_15a> ConsultaListNCM(string descricao, string ncm, int startIndex, int blockSize)
        //{
        //    using (ncmrfEntities conexao = new ncmrfEntities())
        //    {
        //        conexao.Database.CommandTimeout = 300;
        //        if (descricao != null)
        //        {
        //            return (from c in conexao.vw_ncm_full_15a
        //                    where c.ncm == ncm
        //                    && c.descricao_detalhada_produto.Contains(descricao)
        //                    select c).OrderByDescending(c => c.pk_ncmrf_15a).Skip((startIndex - 1) * blockSize).Take(blockSize).ToList();
        //        }
        //        else
        //            return (from c in conexao.vw_ncm_full_15a
        //                    select c).OrderByDescending(c => c.pk_ncmrf_15a).Skip(startIndex).Take(blockSize).ToList();
        //    }
        //}
        //public static vw_ncm_full_15a ConsultaNCM(int idNCM)
        //{
        //    using (ncmrfEntities conexao = new ncmrfEntities())
        //    {
        //        return (from c in conexao.vw_ncm_full_15a
        //                where c.pk_ncmrf_15a == idNCM
        //                select c).FirstOrDefault();
        //    }
        //}

        public static List<ResumoConsulta> ConsultaResumoBusca(string parametro)
        {
            return ConsultaResumoBusca(parametro, "");
        }

        public static List<ResumoConsulta> ConsultaResumoBusca(string parametro, string ncm)
        {
            List<ResumoConsulta> ncms = new List<ResumoConsulta>();

            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ncmrfEntities2"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "SELECT (ROW_NUMBER() OVER (ORDER BY (select null))) as pk_gs, "
                    + "tbb.tx_ncm_desc, tba.ncm, tbb.vl_ift, count(tba.pk_ncmrf_15a) as countReg ,SUM(valor_fob_dolar + valor_frete_dolar + valor_seguro_dolar) AS CIFTot"
                        + " FROM tb_ncmrf_full_15A as tba"
                        + " left join tb_ncm_computada as tbb on tbb.tx_ncm = tba.ncm"
                        + " WHERE ";

                if ((ncm != "") && (ncm != null))
                    query += " ncm = " + ncm + " AND ";

                query += "descricao_detalhada_produto LIKE \'%" + parametro + "%\'";
                query += " GROUP BY tbb.tx_ncm_desc, tba.ncm, tbb.vl_ift";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ResumoConsulta r = new ResumoConsulta();
                            r.tx_ncm_desc = reader.GetValue(1).ToString();
                            r.ncm = reader.GetValue(2).ToString();
                            r.vl_ift = Int32.Parse(reader.GetValue(3).ToString());
                            r.countReg = Int32.Parse(reader.GetValue(4).ToString());
                            r.CIFTot = float.Parse(reader.GetValue(5).ToString());

                            ncms.Add(r);
                        }
                    }
                }
            }
            return ncms;
        }
        public static List<ResumoConsulta> ConsultaResumoBuscaElasticSearch(string parametro, string ncm)
        {
            List<ResumoConsulta> listConsulta = new List<ResumoConsulta>();

            return listConsulta;
        }

        public static void loadStaticNCM()
        {
            if (StaticNCM.ncms.Count == 0) {
                using (ncmrfEntities conexao = new ncmrfEntities())
                {
                    try
                    {
                        var ncms = conexao.tb_ncm_aliq;
                        if (ncms != null)
                            foreach (var ncm in ncms)
                                StaticNCM.ncms.Add(new sNCM(ncm.CODIGO, ncm.DESCRICAO.ToUpper()));
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Erro ao carregar NCMS!");
                    }
                }
            }
        }
    }
}