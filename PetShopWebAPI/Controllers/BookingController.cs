using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;

namespace PetShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IRepo _repo;
        public BookingController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Add(Booking booking)
        {
            _repo.BookingItem(booking);
            return CreatedAtAction(nameof(Add), new { id = booking.ID }, booking);
        }
    }
}
