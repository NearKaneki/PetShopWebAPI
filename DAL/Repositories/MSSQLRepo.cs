﻿using PetShopWebAPI.Entities;

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
            //if (_context.Items.FirstOrDefault(x => x.ID == booking.ItemID) != default(Item))
            //{
            //    if (_context.Clients.FirstOrDefault(x => x.ID == booking.ClientID) != default(Client))
            //    {
            //        if(booking.Amount<=_context.Items.Where(x => x.ID == booking.ItemID).Select(x => x.AmountAvailable).First())
            //        {

            //        }
            //    }
            //}
            _context.Add(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Cathegory> GetCathegories()
        {
            return _context.Cathegories;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items;
        }

        public IEnumerable<Item> GetItemsByCathegory(string cathegoryName)
        {
            int idCathegory = _context.Cathegories.FirstOrDefault(x => x.Name == cathegoryName).ID;
            var SubCathrgories = _context.SubCathegories.Where(x => x.ID == idCathegory).Select(x => x.ID);
            return _context.Items.Where(x => SubCathrgories.Contains(x.SubCathegoryID));
        }

        public Item Get(int idItem)
        {
            return _context.Items.FirstOrDefault(x => x.ID == idItem);
        }

        public IEnumerable<Item> GetItemsBySubCathegory(string subCathegory)
        {
            var SubCathrgories = _context.SubCathegories.Where(x => x.Name == subCathegory).Select(x => x.ID);
            return _context.Items.Where(x => SubCathrgories.Contains(x.SubCathegoryID));
        }

        public IEnumerable<Parameter> GetParameters(int idItem)
        {
            return _context.Parameters.Where(x => x.ItemID == idItem);
        }

        public IEnumerable<SubCathegory> GetSubCathegories()
        {
            return _context.SubCathegories;
        }
    }
}
