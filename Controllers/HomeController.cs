using SoteloProjectFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class HomeController : Controller
    {
        EntidadesSotelo db = new EntidadesSotelo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Success = false;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(tbBuzon model)
        {
            try
            {
                model.BuzonEstatusId = 1;
                model.Estatus = true;
                db.tbBuzon.Add(model);
                db.SaveChanges();
                ViewBag.Success = true;
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Viajes", "ActualizarGastos"));
            }
        }
    }
}