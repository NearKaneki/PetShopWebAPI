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
        public ActionResult<IEnumerable<Item>> Get()=> _repo.GetItems().ToList();

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            Item item = _repo.Get(id);
            if (item == null)
            {
                NotFound();
            }
            return item;
        }

        [HttpGet("Find")]
        public ActionResult<IEnumerable<Item>> GetByFilter(string find)
        {
            List<Item> result = _repo.GetItems().Where(x => x.Name.Contains(find)).ToList();
            return result;
        }

        [HttpGet("cathegory/{cathegoryName}")]
        public ActionResult<IEnumerable<Item>> GetItemsByCathegory(string cathegoryName)
        {
            if (_repo.GetCathegories().FirstOrDefault(x => x.Name == cathegoryName) == null)
            {
                return NotFound();
            }
            return _repo.GetItemsByCathegory(cathegoryName).ToList();
        }

        [HttpGet("subCathegory/{subCathegoryName}")]
        public ActionResult<IEnumerable<Item>> GetItemsBySubCathegory(string subCathegoryName)
        {
            if(_repo.GetSubCathegories().FirstOrDefault(x=>x.Name == subCathegoryName) == null)
            {
                return NotFound();
            }
            return _repo.GetItemsBySubCathegory(subCathegoryName).ToList();
        }
    }
}
