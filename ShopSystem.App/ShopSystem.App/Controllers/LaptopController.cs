using ShopSystem.Models.ViewModels.Laptop;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.App.Controllers
{
    [RoutePrefix("Laptops")]

    public class LaptopController : Controller
    {
        private LaptopsService service;

        public LaptopController()
        {
            this.service = new LaptopsService();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            IEnumerable<LaptopsVm> vms = this.service.GetAllLaptops();

            return this.View(vms);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsLaptopVm vm = this.service.GetDetailsLaptop(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }
    }
}