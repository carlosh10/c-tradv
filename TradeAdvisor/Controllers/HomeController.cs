//using Nest;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Connection;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TradeAdvisor.Models;

namespace TradeAdvisor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(DIDAO.ConsultaDis());
        }

    }
}