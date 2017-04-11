using ShopSystem.Data.Repositories;
using ShopSystem.Models.EntityModels;

namespace ShopSystem.Data.UnitOfWork
{
    public interface IShopSystemData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Laptop> Laptops { get; }

        IRepository<Monitor> Monitors { get; }
    }
}
