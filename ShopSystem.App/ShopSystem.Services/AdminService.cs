using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models.ViewModels.Admin;
using ShopSystem.Models.EntityModels;
using AutoMapper;
using ShopSystem.Models.BindingModels;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using static System.Net.Mime.MediaTypeNames;

namespace ShopSystem.Services
{
    public class AdminService : Service
    {
        public IEnumerable<AdminLaptopsVm> GetAllLapops()
        {
            IEnumerable<Laptop> laptops = this.Context.Laptops;
            IEnumerable<AdminLaptopsVm> vms = Mapper.Map<IEnumerable<Laptop>, IEnumerable<AdminLaptopsVm>>(laptops);

            return vms;
        }

        public AdminDetailsLaptopsVm GetLaptopDetails(int id)
        {
            Laptop laptop = this.Context.Laptops.Find(id);
            if (id == null)
            {
                return null;
            }

            AdminDetailsLaptopsVm vms = Mapper.Map<Laptop, AdminDetailsLaptopsVm>(laptop);
            return vms;
        }

        public void AddNewLaptop(AddLaptopBm bind, IEnumerable<HttpPostedFileBase> images)
        {
            Laptop model = Mapper.Map<AddLaptopBm, Laptop>(bind);
            int i = 1;
            foreach (var img in images)
            {
                if (img != null)
                {                 
                        switch (i)
                        {
                            case 1:
                                model.Image1 = new byte[img.ContentLength];
                                img.InputStream.Read(model.Image1, 0, img.ContentLength);
                                break;
                            case 2:
                                model.Image2 = new byte[img.ContentLength];
                                img.InputStream.Read(model.Image2, 0, img.ContentLength);
                                break;
                            case 3:
                                model.Image3 = new byte[img.ContentLength];
                                img.InputStream.Read(model.Image3, 0, img.ContentLength);
                                break;
                            case 4:
                                model.Image4 = new byte[img.ContentLength];
                                img.InputStream.Read(model.Image4, 0, img.ContentLength);
                                break;
                            case 5:
                                model.Image5 = new byte[img.ContentLength];
                                img.InputStream.Read(model.Image5, 0, img.ContentLength);
                                break;
                        }
                    i++;
                }
            }           
            this.Context.Laptops.Add(model);
            this.Context.SaveChanges();
        }
    }
}
