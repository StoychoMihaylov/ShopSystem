﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopSystem.Models.BindingModels
{
    public class AddLaptopBm
    {
        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        public string Memory { get; set; }

        public string Storage { get; set; }

        public string Processor { get; set; }

        [Display(Name = "Operation System")]

        public string OperationSystem { get; set; }

        public string Display { get; set; }

        public string Graphics { get; set; }

        public string Camera { get; set; }

        public string Battery { get; set; }

        public string Audio { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }

        public byte[] Image4 { get; set; }

        public byte[] Image5 { get; set; }

    }
}
