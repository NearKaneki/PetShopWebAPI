using PetShopWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepo
    {
        IEnumerable<Item> GetItems();
        Item Get(int idItem);
        IEnumerable<Item> GetItemsByCathegory(string cathegoryName);
        IEnumerable<Item> GetItemsBySubCathegory(string subcathegory);
        IEnumerable<Cathegory> GetCathegories();
        IEnumerable<SubCathegory> GetSubCathegories();
        IEnumerable<Parameter> GetParameters(int idItem);
        IEnumerable<Client> GetClients();
        Client Get(string email);
        void AddClient(Client client);
        void BookingItem(Booking booking);
    }
}
