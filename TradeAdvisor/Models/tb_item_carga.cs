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
    
    public partial class tb_item_carga
    {
        public long pk_item_conhecimento { get; set; }
        public long fk_ce_mercante { get; set; }
        public Nullable<int> itemcarga_cdtipoembalagem { get; set; }
        public Nullable<int> itemcarga_cdtipogranel { get; set; }
        public Nullable<int> qthousedeclaradomaster { get; set; }
        public Nullable<int> qthouseinformadomaster { get; set; }
        public Nullable<int> tpitem { get; set; }
        public string usoparcial { get; set; }
        public Nullable<System.DateTime> responsavel_data { get; set; }
        public Nullable<System.DateTime> responsavel_hora { get; set; }
        public Nullable<System.DateTime> dtemissaocemaster { get; set; }
        public Nullable<System.DateTime> dtemissaoce { get; set; }
        public Nullable<double> itemcarga_vlcubagem { get; set; }
        public Nullable<double> itemcarga_vlpesobruto { get; set; }
        public Nullable<double> itemcarga_vlquantidade { get; set; }
        public Nullable<double> itemcarga_vltaracontainer { get; set; }
        public Nullable<double> vlcubagem { get; set; }
        public string tx_url_arquivo { get; set; }
        public string cdAgtNavegMaster { get; set; }
        public string cdconsignatario { get; set; }
        public string nmconsignatario { get; set; }
        public string cdportoorigem { get; set; }
        public string nmportoorigem { get; set; }
        public string cdportodestino { get; set; }
        public string nmportodestino { get; set; }
        public string cdempnavegdesconmaster { get; set; }
        public string itemcarga_cdclassemercadoriaperigosa { get; set; }
        public string itemcarga_cdindicadormercadoriaperigosa { get; set; }
        public string itemcarga_cdlacres { get; set; }
        public string itemcarga_cdncms { get; set; }
        public string itemcarga_descricao { get; set; }
        public string itemcarga_descricao_container { get; set; }
        public string itemcarga_descricao_embalagem { get; set; }
        public string itemcarga_descricao_tipogranel { get; set; }
        public string itemcarga_noncms { get; set; }
        public string itemcarga_nrchassi { get; set; }
        public string itemcarga_nrcontainer { get; set; }
        public string itemcarga_nritem { get; set; }
        public string itemcarga_tipocontainer { get; set; }
        public string itemcarga_txcontramarca { get; set; }
        public string itemcarga_txmarca { get; set; }
        public string nmagtnavegmaster { get; set; }
        public string nmempnavegdesconmaster { get; set; }
        public string nrcemaster { get; set; }
        public string responsavel_cpf { get; set; }
        public string responsavel_ip { get; set; }
        public string responsavel_nome { get; set; }
        public string responsavel_tipo { get; set; }
    
        public virtual tb_ce_mercante tb_ce_mercante { get; set; }
    }
}
