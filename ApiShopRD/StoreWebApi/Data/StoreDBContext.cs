using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreWebApi.Models;

namespace StoreWebApi.Data
{
    public class StoreDBContext:DbContext
    {
        public DbSet<StoreWebApi.Models.Product> Products { get; set; }
        public DbSet<StoreWebApi.Models.User> Users { get; set; }
        public DbSet<StoreWebApi.Models.CarShop> CarShop { get; set; }
        public DbSet<StoreWebApi.Models.Comment> Comments { get; set; }
        public StoreDBContext(DbContextOptions<StoreDBContext> options):base(options)
        {

        }
       
    }
}
