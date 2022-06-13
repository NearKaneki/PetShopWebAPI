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

        [HttpGet("Find")]
        public ActionResult<IEnumerable<Item>> GetByFilter(string find) // To lower Case
        {
            List<Item> result = _repo.GetItems().Where(x =>  x.Name.ToLower().Contains(find.ToLower())).ToList();
            return result;
        }
    }
}
