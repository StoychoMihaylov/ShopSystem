using ShopSystem.Models.BindingModels;
using ShopSystem.Models.ViewModels.Admin;
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

    public class MonitorsController : Controller
    {
        private AdminService service;

        public MonitorsController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route("Monitors")]

        public ActionResult AdminMonitorsList()
        {
            IEnumerable<AdminMonitorsVm> vms = this.service.GetAllMonitors();
            return View(vms);
        }

        [HttpGet]
        [Route("Monitor/Details/{id}")]

        public ActionResult AdminDetailsMonitor(int id)
        {
            AdminDetailsMonitorsVm vm = this.service.GetMonitorDetals(id);
            if (vm == null)
            {
                return HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpGet]
        [Route("Monitor/Add")]

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Monitor/Add")]

        public ActionResult Add(AddMonitorBm bind, IEnumerable<HttpPostedFileBase> Images)
        {
            if (this.ModelState.IsValid)
            {
                foreach (var img in Images)
                {
                    if (img.ContentLength > (5 * 1024 * 1024))
                    {
                        ModelState.AddModelError("Custom Error", "File size must be less than 5 MB");
                        return View();
                    }
                    if (img.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("CustomError", "File type must be \"jpeg\"");
                        return View();
                    }

                    this.service.AddNewMonitor(bind, Images);

                    return RedirectToAction("AdminMonitorsList");
                }
            }

            return this.View();
        }
    }
}