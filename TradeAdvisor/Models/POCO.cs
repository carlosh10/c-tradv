using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class AgregationsPorBucketQtde
    {
        public string name { get; set; }
        public long qtde { get; set; }
    }
    public class AgregationsPorBucketValor
    {
        public string name { get; set; }
        public float valor { get; set; }
    }
    public class DIPOCO
    {
        public long pk_di { get; set; }
        public string tx_cnpj { get; set; }
        public System.DateTime dt_registro { get; set; }
        public string nr_di { get; set; }
        public int nu_totalAdicoes { get; set; }
        public decimal vl_taxaSicomex { get; set; }
        public string tx_cargaPaisProcedenciaNome { get; set; }
        public string tx_cargaUrfEntradaNome { get; set; }
        public Nullable<System.DateTime> dt_dataDesembaraco { get; set; }
        public decimal vl_freteTotalDolares { get; set; }
        public decimal vl_freteTotalReais { get; set; }
        public string tx_importadorCpfRepresentanteLegal { get; set; }
        public string tx_importadorNome { get; set; }
        public string tx_importadorNomeRepresentanteLegal { get; set; }
        public string tx_urfDespachoNome { get; set; }
        public string tx_viaTransporteNome { get; set; }
        public string tx_codigoTipoEmbalagem { get; set; }
        public string tx_codigoNomeEmbalagem { get; set; }
        public Nullable<decimal> nu_quantidadeVolume { get; set; }
        public Nullable<decimal> vl_cargaPesoBruto { get; set; }
        public Nullable<decimal> vl_cargaPesoLiquido { get; set; }
        public string tx_canalSelecaoParametrizada { get; set; }
        public Nullable<decimal> vl_seguroTotalDolares { get; set; }
        public Nullable<decimal> vl_seguroTotalReais { get; set; }

        public virtual ICollection<ADICAOPOCO> tb_adicao { get; set; }
    }
    public class ADICAOPOCO
    {
        public long pk_adicao { get; set; }
        public long fk_di { get; set; }
        public string tx_ncm { get; set; }
        public decimal vl_ii { get; set; }
        public decimal vl_ipi { get; set; }
        public decimal vl_cofins { get; set; }
        public string tx_condicaoVendaIncoterm { get; set; }
        public string tx_condicaoVendaMoedaCodigo { get; set; }
        public string tx_condicaoVendaMoedaNome { get; set; }
        public Nullable<decimal> vl_condicaoVendaValorMoeda { get; set; }
        public string tx_dadosCargaPaisProcedenciaCodigo { get; set; }
        public string tx_dadosCargaPaisProcedenciaNome { get; set; }
        public string tx_dadosCargaUrfEntradaCodigo { get; set; }
        public string tx_dadosCargaUrfEntradaNome { get; set; }
        public string tx_freteMoedaNegociadaCodigo { get; set; }
        public string tx_freteMoedaNegociadaNome { get; set; }
        public decimal vl_freteValorMoedaNegociada { get; set; }
        public decimal vl_freteValorReais { get; set; }
        public string tx_numeroAdicao { get; set; }
        public decimal vl_iiDevido { get; set; }
        public decimal vl_iiRecolher { get; set; }
        public decimal vl_ipiDevido { get; set; }
        public decimal vl_ipiRecolher { get; set; }
        public decimal vl_pisDevido { get; set; }
        public decimal vl_pisRecolher { get; set; }
        public decimal vl_cofinsDevido { get; set; }
        public decimal vl_cofinsRecolher { get; set; }
        public decimal vl_pis { get; set; }
        public string nr_li { get; set; }
        public string tx_fabricanteNome { get; set; }
        public string tx_fornecedorNome { get; set; }
        public string tx_iiFundamentoLegalCodigo { get; set; }
        public string tx_iiFundamentoLegalNome { get; set; }
        public decimal vl_condicaoVendaValorReais { get; set; }
        public string tx_fabricanteCidade { get; set; }
        public string tx_fabricantePais { get; set; }
        public string tx_fabricanteComplemento { get; set; }
        public string tx_fabricanteEstado { get; set; }
        public string tx_fabricanteLogradouro { get; set; }
        public string tx_fabricanteNumero { get; set; }
        public string tx_fornecedorCidade { get; set; }
        public string tx_fornecedorPais { get; set; }
        public string tx_fornecedorComplemento { get; set; }
        public string tx_fornecedorEstado { get; set; }
        public string tx_fornecedorLogradouro { get; set; }
        public string tx_fornecedorNumero { get; set; }
        public Nullable<decimal> vl_dadosMercadoriaPesoLiquido { get; set; }
        public Nullable<decimal> vl_seguroValorReais { get; set; }
        public Nullable<decimal> vl_valorReaisSeguroInternacional { get; set; }
        public Nullable<decimal> vl_acrescimoValorReais { get; set; }
        public string tx_acrescimoDenominacao { get; set; }
        public string tx_acrescimoCodigo { get; set; }
        public decimal iiBaseCalculo { get; set; }
        public decimal pisCofinsBaseCalculoValor { get; set; }

        public virtual DIPOCO tb_di { get; set; }
        public virtual ICollection<MERCADORIAPOCO> tb_mercadoria { get; set; }
    }
    public class MERCADORIAPOCO
    {
        public long pk_mercadoria { get; set; }
        public long fk_adicao { get; set; }
        public string tx_unidadeMedida { get; set; }
        public string tx_descricaoMercadoria { get; set; }
        public string nr_numeroSequenciaItem { get; set; }
        public decimal nu_quantidade { get; set; }
        public decimal vl_valorTotalCondicaoVenda { get; set; }
        public Nullable<decimal> vl_valorUnitario { get; set; }

        public virtual ADICAOPOCO tb_adicao { get; set; }
    }
}