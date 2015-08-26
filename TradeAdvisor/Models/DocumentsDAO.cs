using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class DocumentsDAO
    {
        //public static List<GenericSummaryDocument> ConsultaDocsGeneric(string docList, string docType, int startIndex, int blockSize)
        //{
        //    var docs = new List<GenericSummaryDocument>();

        //    if (docType.Equals("DI"))
        //    {
        //        var dis = DocumentsDAO.ConsultaListDIs(docList, startIndex, blockSize);
        //        foreach (tb_di docOrg in dis)
        //        {
        //            var tempDoc = new GenericSummaryDocument();
        //            tempDoc.nr_document = docOrg.nr_di;
        //            tempDoc.tx_doc_type = docType;
        //            tempDoc.dt_register = docOrg.dt_registro;
        //            tempDoc.dt_operation = docOrg.dt_dataDesembaraco;
        //            tempDoc.vl_freight = (double)docOrg.vl_freteTotalReais;
        //            tempDoc.vl_insurance = (double)docOrg.vl_seguroTotalReais;
        //            tempDoc.vl_gross_weight = docOrg.vl_cargaPesoBruto;
        //            tempDoc.tx_origin_country = NcmDAO.getCountryInitials(docOrg.tx_cargaPaisProcedenciaNome);
        //            tempDoc.tx_discharging = docOrg.tx_urfDespachoNome;
        //            tempDoc.tx_transport_route = docOrg.tx_viaTransporteNome;
        //            tempDoc.tx_chanel = docOrg.tx_canalSelecaoParametrizada;
        //            docs.Add(tempDoc);
        //        }
        //    }
        //    else if (docType.Equals("CE"))
        //    {
        //        var ces = DocumentsDAO.ConsultaListCEs(docList, startIndex, blockSize);
        //        foreach (tb_ce_mercante docOrg in ces)
        //        {
        //            var tempDoc = new GenericSummaryDocument();
        //            tempDoc.nr_document = docOrg.nrcemercante;
        //            tempDoc.tx_doc_type = docType;
        //            tempDoc.dt_register = docOrg.dtemissaoce;
        //            tempDoc.dt_operation = docOrg.dtoperacao;
        //            tempDoc.vl_freight = (double)docOrg.vlfrete;
        //            tempDoc.vl_insurance = 0;
        //            tempDoc.vl_gross_weight = (decimal)docOrg.vlpesobruto;
        //            tempDoc.tx_origin_country = NcmDAO.getCountryInitials(docOrg.nmpaisprocedencia);
        //            tempDoc.tx_discharging = docOrg.nmportodescarregamento;
        //            tempDoc.tx_transport_route = "Marítimo";
        //            tempDoc.tx_chanel = "Não Identificado";
        //            docs.Add(tempDoc);
        //        }
        //    }
        //    else
        //        return new List<GenericSummaryDocument>();

        //    return docs;
        //}
        //public static List<tb_di> ConsultaListDIs(string docList, int startIndex, int blockSize)
        //{
        //    using (tfcoreEntities conexao = new tfcoreEntities())
        //    {
        //        conexao.Database.CommandTimeout = 300;
        //        if (docList != null)
        //        {

        //            var nrs = docList.Split(',');
        //            return (from c in conexao.tb_di
        //                    join nr in nrs on c.nr_di equals nr
        //                    select c).GroupBy(g => g.nr_di).Select(g => g.FirstOrDefault()).OrderByDescending(c => c.nr_di).Skip((startIndex - 1) * blockSize).Take(blockSize).ToList();
        //        }
        //        else
        //            return (from c in conexao.tb_di
        //                    select c).OrderByDescending(c => c.nr_di).Skip(startIndex).Take(blockSize).ToList();
        //    }
        //}

        //public static List<tb_ce_mercante> ConsultaListCEs(string docList, int startIndex, int blockSize)
        //{
        //    using (mercanteEntities conexao = new mercanteEntities())
        //    {
        //        conexao.Database.CommandTimeout = 300;
        //        if (docList != null)
        //        {
        //            var nrs = docList.Split(',');
        //            return (from c in conexao.tb_ce_mercante
        //                    join nr in nrs on c.nrcemercante equals nr
        //                    select c).GroupBy(g => g.nrcemercante).Select(g => g.FirstOrDefault()).OrderByDescending(c => c.nrcemercante).Skip((startIndex - 1) * blockSize).Take(blockSize).ToList();
        //        }
        //        else
        //            return (from c in conexao.tb_ce_mercante
        //                    select c).OrderByDescending(c => c.nrcemercante).Skip(startIndex).Take(blockSize).ToList();
        //    }
        //}

    }
}