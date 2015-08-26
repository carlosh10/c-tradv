using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeAdvisor.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public class JsonModel
        {
            public string HTMLString { get; set; }
            public bool NoMoreData { get; set; }
        }

        //public ActionResult Consulta(string documentList, string docType)
        //{
        //    if (documentList == null || documentList == "")
        //    {
        //        Response.Redirect(@Url.Action("Index", "Home"));
        //        return null;
        //    }

        //    if (docType == null || docType == "")
        //    {
        //        Response.Redirect(@Url.Action("Index", "Home"));
        //        return null;
        //    }

        //    var docs = DocumentsDAO.ConsultaDocsGeneric(documentList, docType, 1, 10);
        //    if (docs.Count == 0)
        //    {
        //        ModelState.AddModelError("", "Não existem registos para este parametro!");
        //        return View();
        //    }
        //    return View(docs);
        //}
    }
}