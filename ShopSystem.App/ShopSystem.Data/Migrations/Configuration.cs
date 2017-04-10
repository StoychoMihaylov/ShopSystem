using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopSystem.Models.EntityModels;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace ShopSystem.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<ShopSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ShopSystemContext";
        }

        protected override void Seed(ShopSystemContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@admin.com", "Admin", "123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }

            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manage.Create(role);
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Laptops.AddOrUpdate(new Laptop[] 
            {
                new Laptop()
                {
                    ModelName = "Lenovo YOGA(13\")",
                    Description = $"Get things done on the go with the Yoga 720 (13\").At only 1.3 kg, the stylishly compact Yoga 720 boasts powerful processing, cutting - edge ports, and the convenience and security of an optional fingerprint login. You’ll enjoy stunning visuals and sound, thanks to a 4K display and premium, enhanced speakers.Whether you’re browsing the web, streaming a movie or working on your own creations, we’ve got you covered.",
                    Memory = "Up to 16GB DDR4",
                    Storage = "Up to 1TB PCle SSD",
                    Processor = $"Up to 7th Gen Intel® Core™ i7",
                    OperationSystem = "Windows 10 Home",
                    Display = "13.3\" 4K UHD (3840 x 2160) / 13.3\" FHD (1920 x 1080) ",
                    Graphics = "Intel® HD Graphics 620",
                    Camera = "HD 720p",
                    Battery = "Up to 8 hours with FHD display",
                    Audio = "2 x JBL speakers",
                    Weight = "1.3kg",
                    Color = "Platinum Silver / Iron Grey Copper",
                    Price = 1333M
                },
                new Laptop()
                {
                    ModelName = "Del Vostro 3568",
                    Description = "15\" (381mm) laptop ideal for professionals.Featuring a large screen, numeric keypad and essential security features.",
                    Memory = "8GB DDR4 2400 MHz ",
                    Storage = "Up to 1 TB",
                    Processor = "Intel® Core™ i3-6006U Processor (3M Cache, up to 2.00 GHz)",
                    OperationSystem = "Free(Linux)",
                    Display = "15\" FHD 1920 x 1080",
                    Graphics = "Intel® HD Graphics",
                    Camera = "HD 720p",
                    Battery = "Up to 7 hours with FHD display",
                    Audio = "2 speakers",
                    Weight = "1.7kg",
                    Color = "Black / Grey / Iron Grey",
                    Price = 900M
                }
            });
           
        }

        private void SetRoleToUser(ShopSystemContext context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email == email).First();

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(ShopSystemContext context, string email, string fullName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            var admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var result = userManager.Create(admin, password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole(ShopSystemContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
