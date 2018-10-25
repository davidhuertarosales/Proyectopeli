using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proyectopeli.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserid = User.Identity.GetUserId();
                var manager = new UserManager<Proyectopeli.Models.ApplicationUser>(new UserStore<Proyectopeli.Models.ApplicationUser>(new Proyectopeli.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserid);
                var Rolid = currentUser.RolID;
                ViewBag.Rol = Rolid;
                var Nombre = currentUser.Nombre;
                ViewBag.Nombre = Nombre;
                var Apellido = currentUser.Apellido;
                ViewBag.Ap = Apellido;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}