using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using TradeAdvisor.Entities;

namespace TradeAdvisor.Models
{
    public class AccountDAO
    {
        public static EmpresaCadastrar CadastrarEmpresa(EmpresaCadastrar model)
        {
            using (tradeadvisorEntities conexao = new tradeadvisorEntities())
            {
                try
                {
                    var empresa = conexao.empresas.Where(c => c.tx_cnpj == model.cnpj).FirstOrDefault();
                    if (empresa == null)
                    {
                        empresa = new empresas();
                        empresa.tx_cnpj = model.cnpj;
                        empresa.tx_bairro_distrito = model.end_bairro;
                        empresa.tx_cep = model.end_cep;
                        empresa.tx_municipio = model.end_municipio;
                        empresa.tx_numero = model.end_numero;
                        empresa.tx_logradouro = model.end_rua;
                        empresa.tx_uf = model.end_uf;
                        empresa.tx_nome_empresarial = model.razao_social;
                        conexao.empresas.Add(empresa);
                        conexao.SaveChanges();
                    }
                    var usuario = conexao.usuarios.Where(c => c.tx_email == model.email_usuario).ToList();
                    if (usuario.Count != 0)
                    {
                        model.mensagem = "Este Email já está Cadastrado!";
                        return model;
                    }

                    usuarios user = new usuarios();
                    user.tx_email = model.email_usuario;
                    user.tx_nome = model.nome_usuario;
                    user.tx_senha = model.senha_usuario;
                    conexao.usuarios.Add(user);
                    conexao.SaveChanges();

                    tb_usuario_empresa userEmp = new tb_usuario_empresa();
                    userEmp.usuarios = user;
                    userEmp.empresas = empresa;
                    conexao.tb_usuario_empresa.Add(userEmp);
                    conexao.SaveChanges();

                    model.mensagem = "Usuário cadastrado com sucesso!";

                    return model;
                }
                catch (Exception x)
                {
                    if (x.GetType() == typeof(DbEntityValidationException))
                    {
                        string lblResposta = "";
                        DbEntityValidationException ex = x as DbEntityValidationException;
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            lblResposta += "Entity of type \"" + eve.Entry.Entity.GetType().Name + "\" in state \"" + eve.Entry.State + "\" has the following validation errors:";
                            foreach (var ve in eve.ValidationErrors)
                                lblResposta += "- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"\n";
                        }
                        TradeAdvisor.Controllers.SistemaController.EnviaNotificacao(lblResposta);
                        string erro = lblResposta;
                    }

                    model.mensagem = "Ocorreu um erro ao registrar, informe o administrador do sistema!";
                    return model;
                }
            }
        }
    }
}