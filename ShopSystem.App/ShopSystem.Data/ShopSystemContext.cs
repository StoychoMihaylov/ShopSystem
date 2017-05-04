namespace ShopSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System.Data.Entity;

    public class ShopSystemContext : IdentityDbContext<ApplicationUser>
    {
        public ShopSystemContext()
            : base("ShopSystem", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Laptop> Laptops { get; set; }

        public virtual DbSet<Monitor> Monitors { get; set; }

        public virtual DbSet<Accessor> Accessoaries { get; set; }

        public static ShopSystemContext Create()
        {
            return new ShopSystemContext();
        }
    }
}