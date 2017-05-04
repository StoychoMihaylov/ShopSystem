using ShopSystem.Models.ViewModels.Accessor;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.App.Controllers
{
    [RoutePrefix("Accessories")]

    public class AccessorController : Controller
    {
        private AccessorService service;

        public AccessorController()
        {
            this.service = new AccessorService();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            IEnumerable<AccessorVm> vms = this.service.GetAllAccessors();

            return this.View(vms);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsAccessorVm vm = this.service.GetDetailsAccessor(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }
    }
}