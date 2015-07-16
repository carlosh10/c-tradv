namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ncm_aliq
    {
        [StringLength(8)]
        public string CODIGO { get; set; }

        public string DESCRICAO { get; set; }

        [StringLength(2)]
        public string UNIDADE_MEDIDA { get; set; }

        [StringLength(6)]
        public string ALIQUOTA_II { get; set; }

        [StringLength(6)]
        public string ALIQUOTA_II_MERCOSUL { get; set; }

        [StringLength(6)]
        public string ALIQUOTA_IPI { get; set; }

        [StringLength(6)]
        public string ALIQUOTA_PIS_ADVAL { get; set; }

        [StringLength(6)]
        public string ALIQUOTA_COFINS_ADVAL { get; set; }

        [Key]
        public int pk_ncm_aliq { get; set; }
    }
}
