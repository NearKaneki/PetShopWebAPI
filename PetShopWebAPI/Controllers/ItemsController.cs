using DAL;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly IRepo _repo;

        public ItemsController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _repo.GetClients();
        }
    }
}
