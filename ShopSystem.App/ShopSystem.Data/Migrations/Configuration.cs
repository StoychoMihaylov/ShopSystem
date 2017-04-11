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

            context.Monitors.AddOrUpdate(new Monitor[] 
            {
                new Monitor()
                {
                    ModelName = "BenQ XL2730Z",
                    Description = "New standards have been set for the finest, smoothest and fastest gameplay experience with the incorporation of perfect motion and fast gaming features in the new XL2730Z. The impeccable combination of QHD resolution, 144Hz refresh rate, 1ms GTG response time and VESA Standard Adaptive-Sync technology with the most powerful gaming gears for precise control, intuitive set-up and gaming eye care will empower professional gamers and gaming enthusiasts to dominate every gameplay time and time again.",
                    LCDSize = "27\"",
                    Resolution = "2560x1440 WQHD @144Hz (HDMI 2.0/ DP)‎",
                    AspectRatio = "16:9",
                    PixelPitch = "0.233‎",
                    USBHub = "USB3.0: Downstream x2 (side); Upstream x1 / USB2.0: Downstream x1 ; Upstream x1 (S Switch Arc) / mini USB",
                    InputConnector = "D-sub / DVI-DL / HDMI 2.0 x1 / HDMI 1.4 x1 / DP1.2‎",
                    IncludedSignalCable = "DVI-DL cable / DP cable / Power cord / USB3.0 / S Switch‎",
                    VESA = "100 x 100mm",
                    AutoGameMode = "YES",
                    LowBlueLight = "YES",
                    FilterFreeTechnology = "YES",
                    Price = 800M
                    
                },
                new Monitor()
                {
                    ModelName = "BenQ RL2755HM",
                    Description = "The RL2755HM is designed to give you the most fluid console gaming experience. The 27”W professional console gaming monitor offers every motion with no latency, low input lag and the best visibility with the latest features: 1ms GTG response time, dual HDMI, the Black eQualizer and image quality supported by BenQ’s world-leading color expertise. So you can stay fiercely competitive while enjoying total gaming satisfaction.",
                    LCDSize = "27\" W",
                    Resolution = "1920 x 1080",
                    AspectRatio = "16:9",
                    PixelPitch = "0.311‎",
                    USBHub = "No",
                    InputConnector = "D-sub / DVI / HDMI x 2 / Headphone jack / Line in‎‎",
                    IncludedSignalCable = "HDMI / audio cable‎‎",
                    VESA = "100 x 100mm",
                    AutoGameMode = "YES",
                    LowBlueLight = "YES",
                    FilterFreeTechnology = "YES",
                    Price = 450M
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
