using Elasticsearch.Net;
using Elasticsearch.Net.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeAdvisor.Models;

namespace TradeAdvisor.Controllers
{
    public class Resultado
    {
        public List<tb_di> dis { get; set; }
    }
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var node = new Uri("http://146.148.79.38:9400");
            var config = new ConnectionConfiguration(node);
            var client = new ElasticsearchClient(config);

            //string query = "{\"query\": {\"match\":  {\"tx_descricaoMercadoria\":\"GAZEBO\"} }}";
            var query = new { query = new { match = new { tx_descricaoMercadoria = "GAZEBO" } } };

            var result = client.Search("documents", "di", query).Response.Values;

            var di = client.GetSource<tb_di>("documents", "di", "1120479683").Response;

            var ce = client.GetSource<tb_ce_mercante>("documents", "cemercante", "161505010415899").Response;

            return View();
        }

    }
}