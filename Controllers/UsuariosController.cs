using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SoteloProjectFramework.Models;
using SoteloProjectFramework.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoteloProjectFramework.Controllers
{
    public class UsuariosController : Controller
    {
        Utilerias util = new Utilerias();
        Sesiones sc = new Sesiones();
        RecursosGenerales rg = new RecursosGenerales();
        FuncionalidadesGenerales fg = new FuncionalidadesGenerales();
        EntidadesSotelo db = new EntidadesSotelo();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            dynamic model = null;
            if (sc.RolUsuarioLogueado != rg.RolMaster)
            {
                model = db.tbUsuarios.Where(x => x.RolId != rg.RolMaster).ToList();
            }
            else
            {
                model = db.tbUsuarios.ToList();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(tbUsuarios model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Contrasenia);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar un correo electrónico con este vínculo
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmar la cuenta", "Para confirmar su cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    #region Registramos en la tabla de usuarios
                    tbUsuarios oModelo = new tbUsuarios();
                    oModelo.Guid = Guid.NewGuid();
                    oModelo.UserId = user.Id;
                    oModelo.RolId = rg.RolAdministradores;
                    oModelo.UserName = model.UserName;
                    oModelo.Nombres = model.Nombres;
                    oModelo.PrimerApellido = model.PrimerApellido;
                    oModelo.SegundoApellido = model.SegundoApellido;
                    oModelo.Contrasenia = model.Contrasenia;
                    oModelo.Email = model.Email;
                    oModelo.Estatus = true;
                    oModelo.Eliminado = false;

                    db.tbUsuarios.Add(oModelo);
                    db.SaveChanges();
                    #endregion

                    #region Configuramos los menus del usuario
                    var UsuarioId = db.tbUsuarios.FirstOrDefault(x => x.UserId == oModelo.UserId).UsuarioId;
                    var Menus = db.cMenus.ToList();
                    foreach (var Menu in Menus)
                    {
                        db.tbMenusRoles.Add(new tbMenusRoles
                        {
                            MenuId = Menu.MenuId,
                            UsuarioId = UsuarioId,
                            Estatus = true
                        });
                    }
                    db.SaveChanges();
                    #endregion

                    //Cargamos las sesiones de la tabla recursos generales
                    rg.CargarSesiones();

                    return RedirectToAction("ConfigPermissions", new { UsuarioId = UsuarioId });
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public ActionResult ConfigPermissions(int UsuarioId)
        {
            var model = db.tbMenusRoles.Where(x => x.UsuarioId == UsuarioId).ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdatePermission(bool Estatus, int MenuId, int UsuarioId)
        {
            AjaxResponse Response = new AjaxResponse();
            try
            {
                var Menu = db.tbMenusRoles.FirstOrDefault(x => x.UsuarioId == UsuarioId && x.MenuId == MenuId);
                Menu.Estatus = Estatus;
                db.SaveChanges();
                Response.Success = true;
            }
            catch (Exception ex)
            {
                Response.Message = ex.Message;
            }
            return Json(Response, JsonRequestBehavior.AllowGet);
        }

    }
}