using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class AccountLoginModel : usuarios
    {
        public string ReturnUrl;
        public bool RememberMe;
    }
    public class EmpresaCadastrar
    {
        public long pk_empresa { get; set; }
        public string razao_social { get; set; }
        public string end_rua { get; set; }
        public string end_numero { get; set; }
        public string end_bairro { get; set; }
        public string end_cep { get; set; }
        public string end_municipio { get; set; }
        public string end_uf { get; set; }
        public Nullable<bool> importador { get; set; }
        public Nullable<bool> exportador { get; set; }
        public string cnpj { get; set; }
        public string nome_usuario { get; set; }
        public string email_usuario { get; set; }
        public string senha_usuario { get; set; }
        public string cargo { get; set; }
        public string mensagem { get; set; }
    }
}