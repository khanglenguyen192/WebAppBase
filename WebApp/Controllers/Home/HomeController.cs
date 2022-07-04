using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {
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

        [AllowAnonymous]
        public ActionResult Login()
        {
            var vm = new LoginModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(LoginModel vm)
        {
            var person = _personService.GetUser(vm.Email, vm.PassCode, vm.IsUsingPhone);
            if (person == null)
                vm.RedirectLink = Url.Action("Login", "Home");
            else
            {
                Session["UserID"] = vm.Email;
                Session["PassCode"] = vm.PassCode;
                FormsAuthentication.SetAuthCookie(vm.Email, false);
                vm.RedirectLink = Url.Action("Home", "Home");
            }    
            return Redirect(vm.RedirectLink);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Home()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}