using SoteloProjectFramework.Models;
using SoteloProjectFramework.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static SoteloProjectFramework.Models.ModelosGenerales;

namespace SoteloProjectFramework.Controllers
{
    public class ConductoresController : Controller
    {
        Sesiones sc = new Sesiones();
        RecursosGenerales rg = new RecursosGenerales();
        FuncionalidadesGenerales fg = new FuncionalidadesGenerales();
        EntidadesSotelo db = new EntidadesSotelo();
        
        // GET: Conductores
        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public AjaxResponse Create(ModeloExtendidoChofer model)
        {
            AjaxResponse Response = new AjaxResponse();
            try
            {
                model.Chofer.Estatus = true;
                model.DetalleChofer.tbChoferes = model.Chofer;
                db.tbDetallesChoferes.Add(model.DetalleChofer);
                db.SaveChanges();
                Response.Success = true;
            }
            catch (Exception ex)
            {
                Response.Message = ex.Message;
            }
            return Response;
        }

        #region Cemex
        public ActionResult Cemex()
        {
            int Categoria = int.Parse(rg.ConductorCEMEX);
            var model = db.tbChoferes.Where(x => x.CategoriaChoferId == Categoria).ToList();
            return View(model);
        }

        public ActionResult CreateCemex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCemex(ModeloExtendidoChofer model)
        {
            if (ModelState.IsValid)
            {
                model.Chofer.CategoriaChoferId = int.Parse(rg.ConductorCEMEX);
                var Result = Create(model);
                if (Result.Success)
                {
                    return RedirectToAction("Cemex");
                }
            }
            return View(model);
        }
        #endregion

        #region Moctezuma
        public ActionResult Moctezuma()
        {
            int Categoria = int.Parse(rg.ConductorMOCTEZUMA);
            var model = db.tbChoferes.Where(x => x.CategoriaChoferId == Categoria).ToList();
            return View(model);
        }

        public ActionResult CreateMoctezuma()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMoctezuma(ModeloExtendidoChofer model)
        {
            if (ModelState.IsValid)
            {
                model.Chofer.CategoriaChoferId = int.Parse(rg.ConductorMOCTEZUMA);
                var Result = Create(model);
                if (Result.Success)
                {
                    return RedirectToAction("Moctezuma");
                }
            }
            return View(model);
        }
        #endregion

    }
}