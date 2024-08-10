using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventario.Controllers;
using inventario.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inventario.Context
{
    public class InventarioDbContext : IdentityDbContext
    {
        
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
        { }

        public DbSet<Produto> Inventario { get; set; }

    }
}