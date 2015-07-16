namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ncm_desc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pk_ncm_desc { get; set; }

        [StringLength(8)]
        public string ncm { get; set; }

        [StringLength(400)]
        public string tx_desc { get; set; }
    }
}
