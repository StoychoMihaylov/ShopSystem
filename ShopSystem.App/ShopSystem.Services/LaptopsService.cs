using AutoMapper;
using ShopSystem.Models.EntityModels;
using ShopSystem.Models.ViewModels.Laptop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services
{
    public class LaptopsService : Service
    {
        public IEnumerable<LaptopsVm> GetAllLaptops()
        {
            IEnumerable<Laptop> laptops = this.Context.Laptops;
            IEnumerable<LaptopsVm> vms = Mapper.Map<IEnumerable<Laptop>, IEnumerable<LaptopsVm>>(laptops);

            return vms;
        }

        public DetailsLaptopVm GetDetailsLaptop(int id)
        {
            Laptop laptop = this.Context.Laptops.Find(id);
            if (laptop == null)
            {
                return null;
            }

            DetailsLaptopVm vm = Mapper.Map<Laptop, DetailsLaptopVm>(laptop);
            return vm;
        }
    }
}
