using Microsoft.EntityFrameworkCore;
using PetShopWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class MSSQLContext: DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) 
        {
            
        }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Cathegory> Cathegorie { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<SubCathegory> SubCathegorie { get; set; }
    }
}
