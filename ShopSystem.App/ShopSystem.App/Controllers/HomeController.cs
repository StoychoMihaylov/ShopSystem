using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.App.Controllers
{
    public class HomeController : Controller
    {
        [Route("home/index")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}