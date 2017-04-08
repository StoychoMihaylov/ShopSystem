using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Data.Repositories;
using ShopSystem.Models.EntityModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShopSystem.Data.UnitOfWork
{
    public class ShopSystemData : IShopSystemData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositorues;

        private IUserStore<ApplicationUser> userStore;

        public ShopSystemData()
            : this(new ShopSystemContext())
        {
        }

        public ShopSystemData(DbContext context)
        {
            this.dbContext = context;
            this.repositorues = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Laptop> Laptops
        {
            get
            {
                return this.GetRepository<Laptop>();
            }
        }

        public IUserStore<ApplicationUser> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<ApplicationUser>(this.dbContext);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (! this.repositorues.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositorues.Add(typeof(T),
                Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositorues[typeof(T)];
        }
    }
}
