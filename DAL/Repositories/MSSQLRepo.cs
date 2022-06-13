using PetShopWebAPI.Entities;

namespace DAL
{
    public class MSSQLRepo : IRepo
    {
        private readonly MSSQLContext _context;

        public MSSQLRepo(MSSQLContext context)
        {
            _context = context;
        }

        public void BookingItem(Booking booking)
        {
            _context.Add(booking);
            _context.SaveChanges();
        }
        
        public Booking GetBooking(int id)
        {
            return _context.Bookings.FirstOrDefault(x => x.ID == id);
        }


        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items;
        }

        public Item Get(int idItem)
        {
            return _context.Items.FirstOrDefault(x => x.ID == idItem);
        }

        public Client Get(string email)
        {
            var clients = _context.Clients.ToList();
            return clients.FirstOrDefault(x => x.Email == email);
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
    }
}
