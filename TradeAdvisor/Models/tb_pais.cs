namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_pais
    {
        [Key]
        [StringLength(4)]
        public Int64 pk_pais { get; set; }

        [Required]
        [StringLength(50)]
        public string tx_descricao { get; set; }

        [Required]
        [StringLength(2)]
        public string tx_sigla { get; set; }
    }
}
