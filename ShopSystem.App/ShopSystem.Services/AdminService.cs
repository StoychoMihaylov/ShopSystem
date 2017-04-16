﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models.ViewModels.Admin;
using ShopSystem.Models.EntityModels;
using AutoMapper;

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
    }
}