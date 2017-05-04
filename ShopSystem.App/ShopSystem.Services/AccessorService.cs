using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models.ViewModels.Accessor;
using ShopSystem.Models.EntityModels;
using AutoMapper;

namespace ShopSystem.Services
{
    public class AccessorService : Service
    {
        public IEnumerable<AccessorVm> GetAllAccessors()
        {
            IEnumerable <Accessor> accessories = this.Context.Accessoaries;
            IEnumerable <AccessorVm> vms = Mapper.Map<IEnumerable<Accessor>, IEnumerable<AccessorVm>>(accessories);

            return vms;
        }

        public DetailsAccessorVm GetDetailsAccessor(int id)
        {
            Accessor accessor = this.Context.Accessoaries.Find(id);
            if (accessor == null)
            {
                return null;
            }

            DetailsAccessorVm vm = Mapper.Map<Accessor, DetailsAccessorVm>(accessor);

            return vm;
        }
    }
}
