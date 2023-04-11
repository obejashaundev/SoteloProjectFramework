using SoteloProjectFramework.Models;
using SoteloProjectFramework.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class ViajesController : Controller
    {
        Utilerias util = new Utilerias();
        Sesiones sc = new Sesiones();
        FuncionalidadesGenerales fg = new FuncionalidadesGenerales();
        RecursosGenerales rg = new RecursosGenerales();
        EntidadesSotelo db = new EntidadesSotelo();
        // GET: Viajes
        public ActionResult Index()
        {
            string Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            var model = db.tbViajes.Where(x => x.FechaStr == Fecha).ToList();
            ViewBag.Hoy = DateTime.Now.ToLongDateString();
            return View(model);
        }

        [ActionName("Create1")]
        public ActionResult Create()
        {
            var lsChoferes = db.tbChoferes.Where(x => !x.Eliminado && x.Estatus).Select(x => new SelectListItem
            {
                Value = x.ChoferId.ToString(),
                Text = x.Nombres + " " + x.PrimerApellido + " " + x.SegundoApellido
            }).OrderBy(x => x.Value).ToList();
            ViewBag.lsChoferes = lsChoferes;
            ViewBag.Hoy = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.Direct = false;
            return View("~/Views/Viajes/Create.cshtml");
        }

        [ActionName("Create2")]
        public ActionResult Create(int ChoferId)
        {
            var lsChoferes = db.tbChoferes.Where(x => x.ChoferId == ChoferId && !x.Eliminado && x.Estatus).Select(x => new SelectListItem
            {
                Value = x.ChoferId.ToString(),
                Text = x.Nombres + " " + x.PrimerApellido + " " + x.SegundoApellido,
                Selected = true
            }).OrderBy(x => x.Value).ToList();
            ViewBag.lsChoferes = lsChoferes;
            ViewBag.Hoy = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.Direct = true;
            return View("~/Views/Viajes/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(ModeloExtendidoViaje model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Viajes.FechaStr = model.Viajes.Fecha.ToString("yyyy-MM-dd");
                    model.Viajes.ChoferId = model.Chofer.ChoferId;
                    model.Viajes.tbContabilidadViaje = model.Contabilidad;
                    db.tbViajes.Add(model.Viajes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var lsChoferes = db.tbChoferes.Where(x => !x.Eliminado && x.Estatus).Select(x => new SelectListItem
            {
                Value = x.ChoferId.ToString(),
                Text = x.Nombres + " " + x.PrimerApellido + " " + x.SegundoApellido
            }).OrderBy(x => x.Value).ToList();
            return View(model);
        }

        public ActionResult Details(int ViajeId)
        {
            ModeloExtendidoViaje model = new ModeloExtendidoViaje();
            model.Viajes = db.tbViajes.FirstOrDefault(x => x.ViajeId == ViajeId);
            model.Chofer = model.Viajes.tbChoferes;
            model.Contabilidad = model.Viajes.tbContabilidadViaje;
            var lsChoferes = db.tbChoferes.Where(x => !x.Eliminado && x.Estatus).Select(x => new SelectListItem
            {
                Value = x.ChoferId.ToString(),
                Text = x.Nombres + " " + x.PrimerApellido + " " + x.SegundoApellido,
                Selected = x.ChoferId == model.Viajes.ChoferId
            }).OrderBy(x => x.Value).ToList();
            ViewBag.lsChoferes = lsChoferes;
            return View(model);
        }

        public ActionResult HistoryDriver(int ChoferId)
        {
            var model = db.tbViajes.Where(x => x.ChoferId == ChoferId).ToList();
            return View(model);
        }

        public ActionResult UpdateDiesel(int ViajeId)
        {
            try
            {
                var model = db.tbViajes.FirstOrDefault(x => x.ViajeId == ViajeId);
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Viajes", "ActualizarGastos"));
            }
        }

        [HttpPost]
        public ActionResult UpdateDiesel(tbViajes model)
        {
            try
            {
                var viaje = db.tbViajes.FirstOrDefault(x => x.ViajeId == model.ViajeId);
                var contabilidad = viaje.tbContabilidadViaje;
                contabilidad.Diesel = model.tbContabilidadViaje.Diesel;
                contabilidad.Ganancia = (contabilidad.Importe - (contabilidad.Diesel + contabilidad.SalarioBrutoChofer)).GetValueOrDefault();
                db.SaveChanges();
                return RedirectToAction("HistoryDriver", new { ChoferId = model.ChoferId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Viajes", "UpdateDiesel"));
            }
        }

        public ActionResult UpdateExpense(int ViajeId)
        {
            try
            {
                var model = db.tbViajes.FirstOrDefault(x => x.ViajeId == ViajeId);
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Viajes", "ActualizarGastos"));
            }
        }

        [HttpPost]
        public ActionResult UpdateExpense(tbViajes model)
        {
            try
            {
                var viaje = db.tbViajes.FirstOrDefault(x => x.ViajeId == model.ViajeId);
                var contabilidad = viaje.tbContabilidadViaje;
                contabilidad.Gastos += model.tbContabilidadViaje.Gastos;
                contabilidad.SalarioNeto = model.tbContabilidadViaje.SalarioNeto;
                //contabilidad.Ganancia = (contabilidad.Importe - (contabilidad.Diesel + contabilidad.SalarioNeto)).GetValueOrDefault();
                db.SaveChanges();
                return RedirectToAction("HistoryDriver", new { ChoferId = model.ChoferId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Viajes", "UpdateExpense"));
            }
        }

    }
}