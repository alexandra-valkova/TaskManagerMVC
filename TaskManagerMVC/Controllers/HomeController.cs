using TaskManagerMVC.Models;
using System.Web.Mvc;

namespace TaskManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Login(username, password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("authenticationError", "Wrong username or password!");
                ViewData["username"] = username;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser != null)
            {
                AuthenticationManager.Logout();
            }

            return RedirectToAction("Login", "Home");
        }
    }
}