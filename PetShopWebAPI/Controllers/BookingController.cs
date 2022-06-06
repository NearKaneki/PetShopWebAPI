using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopWebAPI.Entities;
using System.Net;
using System.Net.Mail;

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
        public ActionResult<string> Add(int itemId, int count, string name, string email)
        {
            string orderNumber = "OrderNumber";
            return Ok(orderNumber);
        }

        [HttpPost("SendEmail")]
        public ActionResult<string> SendEmail(int itemId, int count, string name, string email)
        {
            if (_repo.Get(itemId).AmountAvailable<count)
            {
                return BadRequest("Недостаточно товара");
            }
            string verifCode = RandomString(10);
            //MailAddress fromAddress = new("near55@yandex.ru", "PetShopSaratov");
            //MailAddress toAddress = new(email);
            //MailMessage message = new(fromAddress, toAddress);
            //message.Body = verifCode;
            //message.Subject = "Бронирование на сайте PetShop";

            //SmtpClient smtpClient = new();
            //smtpClient.Host = "smtp.yandex.ru";
            //smtpClient.Port = 465;
            //smtpClient.EnableSsl = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Credentials = new NetworkCredential("near55", "okiyrtpjifgmjflz");

            //smtpClient.Send(message);

            return Ok(verifCode);
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
