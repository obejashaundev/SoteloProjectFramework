using SoteloProjectFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class BuzonController : Controller
    {
        EntidadesSotelo db = new EntidadesSotelo();
        // GET: Buzon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update(ModeloExtendidoBuzon model)
        {
            try
            {
                var buzon = db.tbBuzon.FirstOrDefault(x => x.BuzonId == model.Buzon.BuzonId);
                buzon.BuzonEstatusId = model.Buzon.BuzonEstatusId;
                buzon.Estatus = model.Buzon.Estatus;
                buzon.Eliminado = model.Buzon.Eliminado;
                db.SaveChanges();
                switch (model.Buzon.BuzonEstatusId)
                {
                    case 1:
                        return RedirectToAction("Nuevo");
                    case 2:
                        return RedirectToAction("Nuevo");
                    case 3:
                        if (buzon.Estatus)
                        {
                            return RedirectToAction("Pendiente");
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    default:
                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Buzon", "Update"));
            }
        }

        public ActionResult Nuevo()
        {
            ModeloExtendidoBuzon model = new ModeloExtendidoBuzon();
            model.Buzones = db.tbBuzon.Where(x => x.BuzonEstatusId == 1 && x.Estatus && !x.Eliminado).ToList();
            return View(model);
        }

        public ActionResult Details(int BuzonId, int BuzonEstatusId)
        {
            ModeloExtendidoBuzon model = new ModeloExtendidoBuzon();
            model.Buzones = db.tbBuzon.Where(x => x.BuzonEstatusId == BuzonEstatusId && x.Estatus && !x.Eliminado).ToList();
            model.Buzon = db.tbBuzon.FirstOrDefault(x => x.BuzonId == BuzonId);
            switch (model.Buzon.BuzonEstatusId)
            {
                case 1:
                    return View("~/Views/Buzon/Nuevo.cshtml", model);
                case 2:
                    return View("~/Views/Buzon/Pendiente.cshtml", model);
                case 3:
                    return View("~/Views/Buzon/Atendido.cshtml", model);
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Pendiente()
        {
            ModeloExtendidoBuzon model = new ModeloExtendidoBuzon();
            model.Buzones = db.tbBuzon.Where(x => x.BuzonEstatusId == 2 && x.Estatus && !x.Eliminado ).ToList();
            return View(model);
        }

        public ActionResult Atendido()
        {
            ModeloExtendidoBuzon model = new ModeloExtendidoBuzon();
            model.Buzones = db.tbBuzon.Where(x => x.BuzonEstatusId == 3 && x.Estatus && !x.Eliminado ).ToList();
            return View(model);
        }
    }
}