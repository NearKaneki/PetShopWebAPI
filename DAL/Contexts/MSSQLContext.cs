using Microsoft.EntityFrameworkCore;
using PetShopWebAPI.Entities;

namespace DAL
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Cathegory> Cathegories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<SubCathegory> SubCathegories { get; set; }
    }
}
