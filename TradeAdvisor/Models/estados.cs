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
    
    public partial class estados
    {
        public int id { get; set; }
        public Nullable<int> pk_estado { get; set; }
        public Nullable<int> fk_pais { get; set; }
        public string nome_estado { get; set; }
        public string sigla_estado { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}
