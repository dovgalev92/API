using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseRoom> WarehouseRooms { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
