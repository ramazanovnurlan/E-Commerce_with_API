using E_Commerce_API.Models.Admin.AllMenu;
using E_Commerce_API.RegisterModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Data
{
    public class MyCommerceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public MyCommerceDbContext(DbContextOptions<MyCommerceDbContext> options) : base(options) { }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Submenu> Submenus { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<OpSystem> OpSystems { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<FrontCamera> FrontCameras { get; set; }
        public DbSet<RearCamera> RearCameras { get; set; }
        public DbSet<StyleJoin> StyleJoins { get; set; }
    }
}
