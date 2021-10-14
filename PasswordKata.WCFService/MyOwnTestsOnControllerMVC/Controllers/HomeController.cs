using MyOwnTestsOnControllerMVC.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOwnTestsOnControllerMVC.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 15)]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 15)]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }
    }
}