using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.BindingModels
{
    public class AddAccessorBm
    {
        [Display(Name = "Name")]

        public string NameOfProduct { get; set; }

        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }
    }
}
