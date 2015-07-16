namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ncm_computada
    {
        [Key]
        [StringLength(8)]
        public string tx_ncm { get; set; }

        [StringLength(500)]
        public string tx_ncm_desc { get; set; }

        public double? vl_cif_tot_us { get; set; }

        public int? vl_ift { get; set; }
    }
}
