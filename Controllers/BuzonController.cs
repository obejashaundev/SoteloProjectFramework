﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class BuzonController : Controller
    {
        // GET: Buzon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Pendiente()
        {
            return View();
        }

        public ActionResult Atendido()
        {
            return View();
        }
    }
}