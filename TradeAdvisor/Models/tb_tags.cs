namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_tags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long pk_tag { get; set; }

        [StringLength(100)]
        public string tx_tag { get; set; }
    }
}
