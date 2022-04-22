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

        public IEnumerable<Cathegory> GetCathegories()
        {
            return _context.Cathegory;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Client;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Item;
        }

        public IEnumerable<Item> GetItemsByCathegory(string cathegoryName)
        {
            int idCathegory = _context.Cathegory.FirstOrDefault(x => x.Name == cathegoryName).ID;
            var SubCathrgories = _context.SubCathegory.Where(x => x.ID == idCathegory).Select(x => x.ID);
            return _context.Item.Where(x => SubCathrgories.Contains(x.SubCathegoryID));
        }

        public Item GetItemByID(int idItem)
        {
            return _context.Item.FirstOrDefault(x => x.ID == idItem);
        }

        public IEnumerable<Item> GetItemsBySubCathegory(string subCathegory)
        {
            var SubCathrgories = _context.SubCathegory.Where(x => x.Name == subCathegory).Select(x => x.ID);
            return _context.Item.Where(x => SubCathrgories.Contains(x.SubCathegoryID));
        }

        public IEnumerable<Parameter> GetParameters(int idItem)
        {
            return _context.Parameter.Where(x => x.ItemID == idItem);
        }

        public IEnumerable<SubCathegory> GetSubCathegories()
        {
            return _context.SubCathegory;
        }
    }
}
