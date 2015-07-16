namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ncmrf_full
    {
        [StringLength(32)]
        public string nr_ordem { get; set; }

        [StringLength(12)]
        public string id_mes_ano { get; set; }

        [StringLength(16)]
        public string mes_ano { get; set; }

        [StringLength(16)]
        public string ncm { get; set; }

        [StringLength(60)]
        public string descricao_ncm { get; set; }

        [StringLength(10)]
        public string codigo_pais_origem { get; set; }

        [StringLength(40)]
        public string pais_origem { get; set; }

        [StringLength(6)]
        public string codigo_pais_aquisicao { get; set; }

        [StringLength(40)]
        public string pais_aquisicao { get; set; }

        public int? codigo_unidade_medida_estatistica { get; set; }

        [StringLength(40)]
        public string unidade_medida_estatistica { get; set; }

        [StringLength(40)]
        public string unidade_comercializacao { get; set; }

        [StringLength(500)]
        public string descricao_detalhada_produto { get; set; }

        public double? quantidade_estatistica { get; set; }

        public double? peso_liquido_kg { get; set; }

        public double? valor_fob_dolar { get; set; }

        public double? valor_frete_dolar { get; set; }

        public double? valor_seguro_dolar { get; set; }

        public double? valor_unidade_produto_dolar { get; set; }

        public double? quantidade_comercializada_produto { get; set; }

        public double? valor_total_produto_dolar { get; set; }

        public DateTime? data_ordem { get; set; }

        [Key]
        public long pk_ncmrf { get; set; }
    }
}
