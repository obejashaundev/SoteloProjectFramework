using SoteloProjectFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class UsuariosController : Controller
    {
        EntidadesSotelo db = new EntidadesSotelo();
        // GET: Usuarios
        public ActionResult Index()
        {
            var model = db.tbUsuarios.ToList();
            return View(model);
        }
    }
}