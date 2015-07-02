using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TradeAdvisor.Models;

namespace TradeAdvisor.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (tradeadvisorEntities conexao = new tradeadvisorEntities())
                {
                    //AutenticaGoodData();
                    var user = conexao.tb_usuario.Where(c => c.email == model.email && c.senha == model.senha).FirstOrDefault();
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Login ou senha inválidos!");
                        return View(model);
                    }

                    FormsAuthentication.SetAuthCookie(model.email, true);

                    //Redirecionar no login
                    if (Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            return RedirectToAction("index", "home");
        }
        public ActionResult Cadastrar(EmpresaCadastrar model)
        {
            if (model.cnpj != null)
            {
                model = AccountDAO.CadastrarEmpresa(model);
                ModelState.AddModelError("", model.mensagem);
                return View(model);
            }
            return View(model);
        }
        public static void AutenticaGoodData()
        {
            string baseAddress = "https://portal.comex.guru/";
            string token = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var content = new StringContent("{ \"postUserLogin\": {    \"login\": \"gooddata@comex.guru\",    \"password\": \"Pinho1010\",    \"remember\": 1  }}", System.Text.Encoding.Default, "application/json");
                var result = client.PostAsync("gdc/account/login", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(resultContent);

                var nosJson = doc.DocumentNode.SelectNodes("//pre//a");
                if (nosJson != null)
                    token = nosJson[0].InnerHtml;

                client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                client.DefaultRequestHeaders.TryAddWithoutValidation("cookie", "Set-Cookie: GDCAuthTT=" + token.Replace("/gdc/account/profile/", "") + "; path=/gdc; expires=Mon, 30-Jul-2015 09:12:42 GMT; secure; HttpOnly, GDCAuthSST=; path=/gdc/account; secure; HttpOnly");

                var response = client.GetAsync("gdc/account/token").Result;

                string responseData = response.Content.ReadAsStringAsync().Result;

                string aaaa = responseData + 25 * 2;
            }
        }
    }
}