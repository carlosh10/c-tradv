﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeAdvisor.Models;

namespace TradeAdvisor.Controllers
{
    [Authorize]
    public class NcmController : Controller
    {
        public class JsonModel
        {
            public string HTMLString { get; set; }
            public bool NoMoreData { get; set; }
        }

        public ActionResult Consulta(string descricao, string ncm)
        {
            if (descricao == null || descricao == "")
            {
                Response.Redirect(@Url.Action("Index", "Home"));
                return null;
            }

            if (ncm == null || ncm == "")
            {
                Response.Redirect(@Url.Action("Index", "Home"));
                return null;
            }

            var ncms = NcmDAO.ConsultaListNCM(descricao, ncm, 1, 10);
            if (ncms.Count == 0)
            {
                ModelState.AddModelError("", "Não existem registos para este parametro!");
                return View();
            }
            else
                return View(ncms);
        }
        public ActionResult DetalhesNcm(string idNcm)
        {
            try
            {
                var ncm = NcmDAO.ConsultaNCM(Int32.Parse(idNcm));
                return View(ncm);
            }
            catch (Exception x)
            {
                Response.Redirect(@Url.Action("Index", "Home"));
                return null;
            }
        }

        public ActionResult ResumoConsulta(TradeAdvisor.Models.NcmDAO.ResumoConsulta model)
        {
            if ((@model.descricao_detalhada_produto == null) || (@model.descricao_detalhada_produto == ""))
            {
                ModelState.AddModelError("", "Insira um valor");
                return RedirectToAction("index", "home");
            }
            return View(NcmDAO.ConsultaResumoBusca(@model.descricao_detalhada_produto));
        }

        [HttpPost]
        public ActionResult InfinateScroll(string descricao, string ncm, int BlockNumber)
        {
            //////////////// THis line of code only for demo. Needs to be removed ////
            System.Threading.Thread.Sleep(3000);
            //////////////////////////////////////////////////////////////////////////
            int BlockSize = 10;

            var listNcm = NcmDAO.ConsultaListNCM(descricao, ncm, BlockNumber, BlockSize);
            JsonModel jsonModel = new JsonModel();
            jsonModel.NoMoreData = listNcm.Count < BlockSize;
            jsonModel.HTMLString = RenderPartialViewToString("_NcmBlock", listNcm);
            return Json(jsonModel);
        }
        [HttpPost]
        public ActionResult ResumoConsultaDetalhada(string descricao, string ncm)
        {
            //////////////// THis line of code only for demo. Needs to be removed ////
            System.Threading.Thread.Sleep(3000);
            //////////////////////////////////////////////////////////////////////////
            int BlockSize = 10;

            var listNcm = NcmDAO.ConsultaResumoBusca(descricao, ncm);
            JsonModel jsonModel = new JsonModel();
            jsonModel.NoMoreData = listNcm.Count < BlockSize;
            jsonModel.HTMLString = RenderPartialViewToString("_ResumoConsulta", listNcm);
            return Json(jsonModel);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult =
                ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext
                (ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}