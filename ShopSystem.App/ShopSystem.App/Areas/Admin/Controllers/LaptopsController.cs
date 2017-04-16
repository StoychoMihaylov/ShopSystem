using ShopSystem.Models.BindingModels;
using ShopSystem.Models.EntityModels;
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
    public class LaptopsController : Controller
    {
        private AdminService service;

        public LaptopsController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route("AdminLaptopsList")]

        public ActionResult AdminLaptopsList()
        {
            IEnumerable<AdminLaptopsVm> vms = this.service.GetAllLapops();
            return View(vms);
        }

        [HttpGet]
        [Route("AdminDetailsLaptop/{id}")]

        public ActionResult AdminDetailsLaptop(int id)
        {
            AdminDetailsLaptopsVm vms = this.service.GetLaptopDetails(id);
            if (vms == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vms);
        }

        [HttpGet]
        [Route("Laptop/Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Laptop/Add")]
        public ActionResult Add(AddLaptopBm bind)
        {
            if (this.ModelState.IsValid)
            {
             
                return RedirectToAction("AdminLaptopsList");
            }

            return this.View();
        }
    }
}