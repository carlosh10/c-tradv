using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

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
                    var empresa = conexao.tb_empresa.Where(c => c.cnpj == model.cnpj).FirstOrDefault();
                    if (empresa == null)
                    {
                        empresa = new tb_empresa();
                        empresa.cnpj = model.cnpj;
                        empresa.end_bairro = model.end_bairro;
                        empresa.end_cep = model.end_cep;
                        empresa.end_municipio = model.end_municipio;
                        empresa.end_numero = model.end_numero;
                        empresa.end_rua = model.end_rua;
                        empresa.end_uf = model.end_uf;
                        empresa.exportador = model.exportador;
                        empresa.importador = model.importador;
                        empresa.razao_social = model.razao_social;
                        conexao.tb_empresa.Add(empresa);
                        conexao.SaveChanges();
                    }
                    var usuario = conexao.tb_usuario.Where(c => c.email == model.email_usuario).ToList();
                    if (usuario.Count != 0)
                    {
                        model.mensagem = "Este Email já está Cadastrado!";
                        return model;
                    }

                    tb_usuario user = new tb_usuario();
                    user.email = model.email_usuario;
                    user.nome = model.nome_usuario;
                    user.senha = model.senha_usuario;
                    conexao.tb_usuario.Add(user);
                    conexao.SaveChanges();

                    tb_usuario_empresa userEmp = new tb_usuario_empresa();
                    userEmp.tb_usuario = user;
                    userEmp.tb_empresa = empresa;
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