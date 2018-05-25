using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Practica.Models;

namespace Practica.Context
{
    public class StoreContext: DbContext
    {
        public DbSet<Products> Product { get; set; }
    }
}