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
    
    public partial class tb_usuario_acesso
    {
        public long pk_usuario_acesso { get; set; }
        public System.DateTime dt_ocorrencia { get; set; }
        public string id_usuario { get; set; }
        public string tipo_pagina { get; set; }
        public long fk_registro { get; set; }
    }
}
