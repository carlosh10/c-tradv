//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeAdvisor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_alteracao
    {
        public long pk_alteracao { get; set; }
        public long fk_importacao { get; set; }
        public string nm_tablea { get; set; }
        public string nm_campo { get; set; }
        public string vl_anterior { get; set; }
        public string vl_novo { get; set; }
    }
}
