using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.ViewModels.Accessor
{
    public class AccessorVm
    {
        public int Id { get; set; }

        [Display(Name = "Name")]

        public string NameOfProduct { get; set; }

        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }
    }
}
