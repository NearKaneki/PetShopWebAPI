using DAL;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CathegoryController : Controller
    {
        private readonly IRepo _repo;
        public CathegoryController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cathegory>> GetCathegories()
        {
            return _repo.GetCathegories().ToList();
        }
    }
}
