using ShopSystem.Models.EntityModels;
using ShopSystem.Models.ViewModels.Monitor;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.App.Controllers
{
    [RoutePrefix("Monitor")]
    public class MonitorController : Controller
    {
        private MonitorsService service;

        public MonitorController()
        {
            this.service = new MonitorsService();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            IEnumerable<MonitorsVm> vms = this.service.GetAllMonitors();

            return this.View(vms);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsMonitorVm vms = this.service.GetDetails(id);
            if (vms == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vms);
        }
    }
}