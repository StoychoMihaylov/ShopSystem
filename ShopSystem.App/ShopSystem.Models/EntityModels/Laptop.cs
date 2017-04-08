using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models.EntityModels
{
    public class Laptop
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string Description { get; set; }

        public string RAMMemory { get; set; }

        public string Procesor { get; set; }

        public string Display { get; set; }

        public decimal Price { get; set; }
    }
}
