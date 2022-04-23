using DAL;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParameterController : Controller
    {
        private readonly IRepo _repo;
        public ParameterController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{idItem}")]
        public ActionResult<IEnumerable<Parameter>> GetParameters(int idItem)
        {
            if (_repo.Get(idItem) == null)
            {
                return NotFound();
            }
            return _repo.GetParameters(idItem).ToList();
        }
    }
}
