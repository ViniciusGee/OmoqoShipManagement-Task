using Microsoft.EntityFrameworkCore;
using Omoqo.ShipManagement.Domain.Ships.Models;
using Omoqo.ShipManagement.Infra.Mappings;
using System;

namespace Omoqo.ShipManagement.Infra
{
    public class ShipManagementDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; } = default!;

        public ShipManagementDbContext(DbContextOptions<ShipManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShipMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("DataSource=app.db");
            //optionsBuilder.ApplyDefaultConfiguration(_logger.LogEntityMessage, _environment.IsDevelopment());
        }
    }
}
