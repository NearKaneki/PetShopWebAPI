using Microsoft.EntityFrameworkCore;
using PetShopWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MSSQLRepo : IRepo
    {
        private  readonly MSSQLContext _context;

        public MSSQLRepo(MSSQLContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetClients()
        {
            return _context.Client;
        }
    }
}
