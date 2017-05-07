using ShopSystem.Models.BindingModels;
using ShopSystem.Models.EntityModels;
using ShopSystem.Models.ViewModels.Admin;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

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
        [Route("List")]

        public ActionResult AdminLaptopsList()
        {
            IEnumerable<AdminLaptopsVm> vms = this.service.GetAllLapops();
            return View(vms);
        }
     
        [HttpGet]
        [Route("Laptop/Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Laptop/Add")]
        public ActionResult Add(AddLaptopBm bind, IEnumerable<HttpPostedFileBase> images)
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
                this.service.AddNewLaptop(bind, images);

                return RedirectToAction("AdminLaptopsList");
            }

            return this.View();
        }

        [HttpGet]
        [Route("Delete/{id}")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminDeleteLaptopVm vm = this.service.GetLaptopTowardDelete(id);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            this.service.DeleteLaptop(id);
            
            return RedirectToAction("AdminLaptopsList");
        }

        [HttpGet]
        [Route("Edit/{id}")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminEditLaptopVm vm = this.service.GetLaptopTowardEdit(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("Edit/{id}")]

        public ActionResult EditConfirmed(AdminEditLaptopVm laptop)
        {
            if (ModelState.IsValid)
            {
                if (laptop == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
          
                this.service.EditLaptop(laptop);

                return RedirectToAction("AdminLaptopsList");
                
            }

            return this.View();
        }
    }
}