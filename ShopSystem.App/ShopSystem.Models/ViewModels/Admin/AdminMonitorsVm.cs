using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.ViewModels.Admin
{
    public class AdminMonitorsVm
    {
        public int Id { get; set; }

        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public decimal Price { get; set; }

        public byte[] Image1 { get; set; }
    }
}
