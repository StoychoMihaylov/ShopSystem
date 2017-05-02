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

        public IEnumerable<AdminMonitorsVm> GetAllMonitors()
        {
            IEnumerable<Monitor> monitors = this.Context.Monitors;
            IEnumerable<AdminMonitorsVm> vms = Mapper.Map<IEnumerable<Monitor>, IEnumerable<AdminMonitorsVm>>(monitors);

            return vms;
        }

        public AdminDetailsMonitorsVm GetMonitorDetals(int id)
        {
            Monitor monitor = this.Context.Monitors.Find(id);
            if (monitor == null)
            {
                return null;
            }

            AdminDetailsMonitorsVm vm = Mapper.Map<Monitor, AdminDetailsMonitorsVm>(monitor);
            return vm;
        }

        public AdminDetailsLaptopsVm GetLaptopDetails(int id)
        {
            Laptop laptop = this.Context.Laptops.Find(id);
            if (laptop == null)
            {
                return null;
            }

            AdminDetailsLaptopsVm vm = Mapper.Map<Laptop, AdminDetailsLaptopsVm>(laptop);
            return vm;
        }

        public void AddNewLaptop(AddLaptopBm bind, IEnumerable<HttpPostedFileBase> images)
        {
            Laptop laptop = Mapper.Map<AddLaptopBm, Laptop>(bind);
            int i = 1;
            foreach (var img in images)
            {
                if (img != null)
                {                 
                        switch (i)
                        {
                            case 1:
                                laptop.Image1 = new byte[img.ContentLength];
                                img.InputStream.Read(laptop.Image1, 0, img.ContentLength);
                                break;
                            case 2:
                                laptop.Image2 = new byte[img.ContentLength];
                                img.InputStream.Read(laptop.Image2, 0, img.ContentLength);
                                break;
                            case 3:
                                laptop.Image3 = new byte[img.ContentLength];
                                img.InputStream.Read(laptop.Image3, 0, img.ContentLength);
                                break;
                            case 4:
                                laptop.Image4 = new byte[img.ContentLength];
                                img.InputStream.Read(laptop.Image4, 0, img.ContentLength);
                                break;
                            case 5:
                                laptop.Image5 = new byte[img.ContentLength];
                                img.InputStream.Read(laptop.Image5, 0, img.ContentLength);
                                break;
                        }
                    i++;
                }
            }           
            this.Context.Laptops.Add(laptop);
            this.Context.SaveChanges();
        }

        public void AddNewMonitor(AddMonitorBm bind, IEnumerable<HttpPostedFileBase> images)
        {
            Monitor monitor = Mapper.Map<AddMonitorBm, Monitor>(bind);
            int i = 1;
            foreach (var img in images)
            {
                if (img != null)
                {
                    switch (i)
                    {
                        case 1:
                            monitor.Image1 = new byte[img.ContentLength];
                            img.InputStream.Read(monitor.Image1, 0, img.ContentLength);
                            break;
                        case 2:
                            monitor.Image2 = new byte[img.ContentLength];
                            img.InputStream.Read(monitor.Image2, 0, img.ContentLength);
                            break;
                        case 3:
                            monitor.Image3 = new byte[img.ContentLength];
                            img.InputStream.Read(monitor.Image3, 0, img.ContentLength);
                            break;
                        case 4:
                            monitor.Image4 = new byte[img.ContentLength];
                            img.InputStream.Read(monitor.Image4, 0, img.ContentLength);
                            break;
                        case 5:
                            monitor.Image5 = new byte[img.ContentLength];
                            img.InputStream.Read(monitor.Image5, 0, img.ContentLength);
                            break;
                    }
                    i++;
                }
            }
            this.Context.Monitors.Add(monitor);
            this.Context.SaveChanges();
        }
    }
}
