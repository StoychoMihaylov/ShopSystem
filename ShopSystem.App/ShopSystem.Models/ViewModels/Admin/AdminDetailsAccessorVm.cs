using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.ViewModels.Admin
{
    public class AdminDetailsAccessorVm
    {
        public int Id { get; set; }

        [Display(Name = "Name")]

        public string NameOfProduct { get; set; }

        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public string Discriptio1 { get; set; }

        public string Discription2 { get; set; }

        public string Discription3 { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }
    }
}
