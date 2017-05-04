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
        [Route("Laptops")]

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
    }
}