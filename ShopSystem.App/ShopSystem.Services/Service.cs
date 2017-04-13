using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new ShopSystemContext();
        }

        protected ShopSystemContext Context { get; }
    }
}
