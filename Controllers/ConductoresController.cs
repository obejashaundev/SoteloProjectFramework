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
        Utilerias util = new Utilerias();
        Sesiones sc = new Sesiones();
        RecursosGenerales rg = new RecursosGenerales();
        FuncionalidadesGenerales fg = new FuncionalidadesGenerales();
        EntidadesSotelo db = new EntidadesSotelo();
        
        // GET: Conductores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info(int ChoferId)
        {
            var model = db.tbChoferes.FirstOrDefault(x => x.ChoferId == ChoferId);
            return View(model);
        }

        public ActionResult Cemex()
        {
            int Categoria = int.Parse(rg.ConductorCEMEX);
            var model = db.tbChoferes.Where(x => x.CategoriaChoferId == Categoria && x.Estatus && !x.Eliminado).ToList();
            return View(model);
        }

        public ActionResult Moctezuma()
        {
            int Categoria = int.Parse(rg.ConductorMOCTEZUMA);
            var model = db.tbChoferes.Where(x => x.CategoriaChoferId == Categoria && x.Estatus && !x.Eliminado).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var lsCategoriasChofer = db.tbCategoriasChoferes.Select(x => new SelectListItem
            {
                Value = x.CategoriaChoferId.ToString(),
                Text = x.Descripcion
            }).ToList();
            ViewBag.lsCategoriasChofer = lsCategoriasChofer;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloExtendidoChofer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase file = Request.Files["foto"];
                    if (file != null)
                    {
                        model.Chofer.Imagen = util.ConvertToBytes(file);
                    }
                    model.DetalleChofer.FechaNacimientoStr = model.DetalleChofer.FechaNacimiento.ToString("yyyy-MM-dd");
                    model.Chofer.Estatus = true;
                    model.DetalleChofer.tbChoferes = model.Chofer;
                    db.tbDetallesChoferes.Add(model.DetalleChofer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(model);
        }

        public ActionResult Details(int ChoferId)
        {
            ModeloExtendidoChofer model = new ModeloExtendidoChofer();
            model.Chofer = db.tbChoferes.FirstOrDefault(x => x.ChoferId == ChoferId);
            model.DetalleChofer = model.Chofer.tbDetallesChoferes.FirstOrDefault();
            var lsCategoriasChofer = db.tbCategoriasChoferes.Select(x => new SelectListItem
            {
                Value = x.CategoriaChoferId.ToString(),
                Text = x.Descripcion,
                Selected = x.CategoriaChoferId == model.Chofer.CategoriaChoferId
            }).ToList();
            ViewBag.lsCategoriasChofer = lsCategoriasChofer;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ModeloExtendidoChofer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase file = Request.Files[0];
                        if (file != null)
                        {
                            model.Chofer.Imagen = util.ConvertToBytes(file);
                        }
                    }
                    model.DetalleChofer.FechaNacimiento = DateTime.Parse(model.DetalleChofer.FechaNacimientoStr);
                    var Chofer = db.tbChoferes.FirstOrDefault(x => x.ChoferId == model.Chofer.ChoferId);
                    var DetalleChofer = Chofer.tbDetallesChoferes.FirstOrDefault();

                    Chofer.CategoriaChoferId = model.Chofer.CategoriaChoferId;
                    Chofer.Nombres = model.Chofer.Nombres;
                    Chofer.PrimerApellido = model.Chofer.PrimerApellido;
                    Chofer.SegundoApellido = model.Chofer.SegundoApellido;
                    Chofer.Imagen = model.Chofer.Imagen;

                    DetalleChofer.Unidad = model.DetalleChofer.Unidad;
                    DetalleChofer.PlacasUnidad = model.DetalleChofer.PlacasUnidad;
                    DetalleChofer.DescripcionUnidad = model.DetalleChofer.DescripcionUnidad;
                    DetalleChofer.Edad = model.DetalleChofer.Edad;
                    DetalleChofer.FechaNacimiento = model.DetalleChofer.FechaNacimiento;
                    DetalleChofer.FechaNacimientoStr = model.DetalleChofer.FechaNacimientoStr;
                    DetalleChofer.LicenciaConducir = model.DetalleChofer.LicenciaConducir;
                    DetalleChofer.NSS = model.DetalleChofer.NSS;

                    db.SaveChanges();
                    return RedirectToAction("Details", new { ChoferId = Chofer.ChoferId });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View("~/Views/Conductores/Details.cshtml", model);
        }

        public ActionResult Delete(int ChoferId)
        {
            ModeloExtendidoChofer model = new ModeloExtendidoChofer();
            model.Chofer = db.tbChoferes.FirstOrDefault(x => x.ChoferId == ChoferId);
            //model.DetalleChofer = model.Chofer.tbDetallesChoferes.FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ModeloExtendidoChofer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Chofer = db.tbChoferes.FirstOrDefault(x => x.ChoferId == model.Chofer.ChoferId);
                    Chofer.Estatus = false;
                    Chofer.Eliminado = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(model.Chofer.tbCategoriasChoferes.Descripcion);
        }

    }
}