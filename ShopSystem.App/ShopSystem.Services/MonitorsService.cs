using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models.ViewModels.Monitor;
using ShopSystem.Models.EntityModels;
using AutoMapper;

namespace ShopSystem.Services
{
    public class MonitorsService : Service
    {
        public IEnumerable<MonitorsVm> GetAllMonitors()
        {
            IEnumerable<Monitor> monitors = this.Context.Monitors;
            IEnumerable<MonitorsVm> vms = Mapper.Map<IEnumerable<Monitor>, IEnumerable<MonitorsVm>>(monitors);

            return vms;
        }

        public DetailsMonitorVm GetDetails(int id)
        {
            Monitor monitor = this.Context.Monitors.Find(id);
            if (monitor == null)
            {
                return null;
            }

            DetailsMonitorVm vm = Mapper.Map<Monitor, DetailsMonitorVm>(monitor);
            return vm;
        }
    }
}
