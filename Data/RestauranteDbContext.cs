using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class RestauranteDbContext: DbContext
    {
        public RestauranteDbContext(DbContextOptions op) : base(op){}
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
    }
}
