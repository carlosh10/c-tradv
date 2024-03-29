﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Entities
{
    public class PRODUTOS_SENSIVEIS_POCO
    {
        public long pk_ncmrf_15a { get; set; }
        public string nr_ordem { get; set; }
        public string id_mes_ano { get; set; }
        public string mes_ano { get; set; }
        public string ncm { get; set; }
        public string codigo_pais_origem { get; set; }
        public string codigo_pais_aquisicao { get; set; }
        public Nullable<int> codigo_unidade_medida_estatistica { get; set; }
        public string unidade_comercializacao { get; set; }
        public string descricao_detalhada_produto { get; set; }
        public Nullable<double> valor_fob_dolar { get; set; }
        public Nullable<double> valor_frete_dolar { get; set; }
        public Nullable<double> valor_seguro_dolar { get; set; }
        public Nullable<double> acrescimos { get; set; }
        public Nullable<double> CIF { get; set; }
        public Nullable<double> CIF_unitario { get; set; }
        public Nullable<double> valor_unidade_produto_dolar { get; set; }
        public Nullable<double> quantidade_comercializada_produto { get; set; }
        public Nullable<double> valor_total_produto_dolar { get; set; }
        public Nullable<double> Expr1 { get; set; }
        public string DESCRICAO { get; set; }
        public string ALIQUOTA_II { get; set; }
        public string ALIQUOTA_IPI { get; set; }
        public string ALIQUOTA_PIS_ADVAL { get; set; }
        public string ALIQUOTA_COFINS_ADVAL { get; set; }
        public Nullable<double> valor_II { get; set; }
        public Nullable<double> valor_IPI { get; set; }
        public Nullable<double> valor_PIS { get; set; }
        public Nullable<double> valor_COFINS { get; set; }
        public Nullable<decimal> vl_ift { get; set; }
        public Nullable<double> quantidade_aduaneira { get; set; }
        public string ncmDescricao { get; set; }
        public string unidade_aduaneira { get; set; }
        public Nullable<System.DateTime> data_ordem { get; set; }
        public string siglaPaisOrigem { get; set; }
        public string paisOrigem { get; set; }
        public string siglaPaisAquisicao { get; set; }
        public string paisAquisicao { get; set; }
    }
}