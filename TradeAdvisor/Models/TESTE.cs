namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTE")]
    public partial class TESTE
    {
        [Key]
        public int PID { get; set; }

        [StringLength(6)]
        public string TT { get; set; }
    }
}
