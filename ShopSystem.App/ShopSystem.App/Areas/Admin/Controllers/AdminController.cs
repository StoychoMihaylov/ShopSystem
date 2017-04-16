using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminController : Controller
    {

        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route("Action")]
        public ActionResult Action()
        {
            return View();
        }
    }
}