using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Entities
{
    public class AgregationsPorBucketQtde
    {
        public string name { get; set; }
        public Nullable<long> qtde { get; set; }
        public string url { get; set; }
        public string desc { get; set; }
    }
    public class AgregationsPorBucketValor
    {
        public string name { get; set; }
        public float valor { get; set; }
        public string url { get; set; }
        public string desc { get; set; }
    }
    public class AgregationsPorBucketQtdexDate
    {
        public string name { get; set; }
        public long qtde { get; set; }
        public string eventdate { get; set; }
    }

    public class ResumoConsulta
    {
        public string tx_ncm_desc { get; set; }
        public string ncm { get; set; }
        public float vl_ift { get; set; }
        public float vl_ii { get; set; }
        public float vl_ipi { get; set; }
        public float vl_pis { get; set; }
        public float vl_cofins { get; set; }
        public float vl_aliq_total { get; set; }
        public long countReg { get; set; }
        public float CIFTot { get; set; }

        public string descricao_detalhada_produto { get; set; }
    }

    public class ResumoConsultaDetalhada
    {
        public float vl_ift { get; set; }
        public long countReg { get; set; }
    }
    public class GenericSummaryDocument
    {
        public string nr_document { get; set; }
        public string tx_doc_type { get; set; }
        public Nullable<System.DateTime> dt_register { get; set; }
        public Nullable<System.DateTime> dt_operation { get; set; }
        public Nullable<double> vl_freight { get; set; }
        public Nullable<double> vl_insurance { get; set; }
        public Nullable<decimal> vl_quantity { get; set; }
        public Nullable<decimal> vl_gross_weight { get; set; }
        public string tx_origin_country { get; set; }
        public string tx_discharging { get; set; }
        public string tx_transport_route { get; set; }
        public string tx_chanel { get; set; }
    }    
}