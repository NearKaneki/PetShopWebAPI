using DAL;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [ApiController]
    [Route("{api/[controller]}")]
    public class SubCathegoryController : Controller
    {
        private readonly IRepo _repo;
        public SubCathegoryController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<SubCathegory> GetSubCathegories()
        {
            return _repo.GetSubCathegories();
        }
    }
}
