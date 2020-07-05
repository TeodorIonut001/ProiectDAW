using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext() : base("DBConnectionString") { }
        public DbSet<Shopping> Shoppings { get; set; }
        
    }
}