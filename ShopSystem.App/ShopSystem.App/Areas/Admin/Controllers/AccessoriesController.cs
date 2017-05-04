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
    [Authorize(Roles = ("Admin"))]
    [RouteArea("Admin")]
    public class AccessoriesController : Controller
    {
        private AdminService service;

        public AccessoriesController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route("Accessories")]

        public ActionResult AdminAccessoriesList()
        {
            IEnumerable<AdminAccessoriesVm> vms = this.service.GetAllAccessors();

            return View(vms);
        }
   
        [HttpGet]
        [Route("Accessor/Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Accessor/Add")]
        public ActionResult Add(AddAccessorBm bind, IEnumerable<HttpPostedFileBase> images)
        {
            if (this.ModelState.IsValid)
            {
                foreach (var img in images)
                {
                    if (img != null)
                    {
                        if (img.ContentLength > (5 * 1024 * 1024))
                        {
                            ModelState.AddModelError("CustomError", "File size must be less than 5 MB");
                            return View();
                        }
                        if (img.ContentType != "image/jpeg")
                        {
                            ModelState.AddModelError("CustomError", "File type must be \"jpeg\"");
                            return View();
                        }
                    }                  
                }
                this.service.AddNewAccessor(bind, images);

                return RedirectToAction("AdminAccessoriesList");
            }

            return this.View();
        }

    }
}