﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Entities
{
    public class CE_POCO
    {
        public long pk_mercante { get; set; }
        public long fk_importacao { get; set; }
        public bool master { get; set; }
        public string nrcemercante { get; set; }
        public string nrcemercantemaster { get; set; }
        public Nullable<System.DateTime> dtceorigem { get; set; }
        public Nullable<System.DateTime> dtemissao { get; set; }
        public Nullable<System.DateTime> dtemissaoce { get; set; }
        public System.DateTime dtoperacao { get; set; }
        public Nullable<System.DateTime> responsavel_data_conhec { get; set; }
        public Nullable<bool> bloqueio_conhecimento { get; set; }
        public Nullable<double> vlcubagem { get; set; }
        public Nullable<double> vlfrete { get; set; }
        public Nullable<double> vlfretetotal { get; set; }
        public Nullable<double> vlpesobruto { get; set; }
        public Nullable<double> afrmm { get; set; }
        public Nullable<double> afrmm_total_devido { get; set; }
        public Nullable<double> afrmm_valor_juros { get; set; }
        public Nullable<double> afrmm_valor_multa { get; set; }
        public Nullable<double> cotacao_moeda_frete { get; set; }
        public string cdagencianavegacao { get; set; }
        public string tx_url_arquivo { get; set; }
        public string cdconsignatario { get; set; }
        public string cdembarcacao { get; set; }
        public string cdempresanavegacao { get; set; }
        public string cdmoedafrete { get; set; }
        public string cdnotifypart { get; set; }
        public string cdpaisprocedencia { get; set; }
        public string cdportocarregamento { get; set; }
        public string cdportodescarregamento { get; set; }
        public string cdportodestino { get; set; }
        public string cdportoorigem { get; set; }
        public string cdportooriginal { get; set; }
        public string cdpracaentexterior { get; set; }
        public string cdshipper { get; set; }
        public string cdterminalportuario { get; set; }
        public string cdterminalportuariocarregamento { get; set; }
        public string ckblservico { get; set; }
        public string ckshipsconvenience { get; set; }
        public string indblordem { get; set; }
        public string indmodalidadefrete { get; set; }
        public string indufdestino { get; set; }
        public string nmagencianavegacao { get; set; }
        public string nmconsignatario { get; set; }
        public string nmembarcacao { get; set; }
        public string nmempresanavegacao { get; set; }
        public string nmmoedafrete { get; set; }
        public string nmnavioorigem { get; set; }
        public string nmpaisprocedencia { get; set; }
        public string nmportocarregamento { get; set; }
        public string nmportodescarregamento { get; set; }
        public string nmportodestino { get; set; }
        public string nmportoorigem { get; set; }
        public string nmportooriginal { get; set; }
        public string nmpracaentexterior { get; set; }
        public string nmterminalportuario { get; set; }
        public string nmterminalportuariocarregamento { get; set; }
        public string nmufdestino { get; set; }
        public string nrblconhecimento { get; set; }
        public string nrceorigem { get; set; }
        public string nrceoriginal { get; set; }
        public string nrmanifesto { get; set; }
        public string nrviagem { get; set; }
        public string opconsignatario { get; set; }
        public string oprecolhimentofrete { get; set; }
        public string pendencia_transito_maritimo { get; set; }
        public string qtconhecimentosassociado { get; set; }
        public string qtconhecimentosexistentes { get; set; }
        public string qtconhecimentosinformados { get; set; }
        public string qtveiculostransportadores { get; set; }
        public string responsavel_cpf_conhec { get; set; }
        public string responsavel_ip_conhec { get; set; }
        public string responsavel_nome_conhec { get; set; }
        public string responsavel_tipo_conhec { get; set; }
        public string ret_pendente_analise { get; set; }
        public string revisao_ou_pendencia_afrmm { get; set; }
        public string situacao_endosso { get; set; }
        public string tipoconhecimento { get; set; }
        public string tipoconsulta { get; set; }
        public string tptrafego { get; set; }
        public string transbordosexterior { get; set; }
        public string txconsignatario { get; set; }
        public string txmercadoria { get; set; }
        public string txnotifypart { get; set; }
        public string txobservacoes { get; set; }
        public string txshipper { get; set; }
        public string componentesfrete { get; set; }
        public string cdterminalportuariodescarregamento { get; set; }
        public string nmterminalportuariodescarregamento { get; set; }
        public string cdagdescolsolidadora { get; set; }
        public string nmagdescolsolidadora { get; set; }
        public string cdempresanvocc { get; set; }
        public string nmempresanvocc { get; set; }

        public virtual ICollection<ITEM_CARGA_POCO> tb_item_carga { get; set; }
    }
    public class ITEM_CARGA_POCO
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
    }
}