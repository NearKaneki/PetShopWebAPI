using DAL;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IRepo _repo;

        public ItemsController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _repo.GetItems();
        }

        [HttpGet("{id}")]
        public Item GetItem(int id)
        {
            return _repo.GetItemByID(id);
        }

        [HttpGet("{cathegoryName}")]
        public IEnumerable<Item> GetItemsByCathegory(string cathegoryName)
        {
            return _repo.GetItemsByCathegory(cathegoryName);
        }

        [HttpGet("{subCathegoryName}")]
        public IEnumerable<Item> GetItemsBySubCathegory(string subCathegoryName)
        {
            return _repo.GetItemsBySubCathegory(subCathegoryName);
        }
    }
}
