using DAL;
using Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PetShopWebAPI.Entities;
using System.Net;


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
        public ActionResult<string> Add(DtoForBooking dto)
        {
            Client client = _repo.Get(dto.Email);
            if (client == null)
            {
                _repo.AddClient(new Client() { Name = dto.Name, Email = dto.Email });
                client = _repo.Get(dto.Email);
            } 
            

            _repo.BookingItem(new Booking()
            {
                ClientID = client.ID,
                ItemID = dto.ItemId,
                Amount = dto.Count,
                BookingDate = DateTime.Now,
                BookingNumber = dto.OdredNumber,
                BookingStatus = "Забронировано"
            });
            return Ok();
        }

        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail(DtoForBooking dto)
        {
            if (_repo.Get(dto.ItemId).AmountAvailable < dto.Count)
            {
                return BadRequest("Недостаточно товара");
            }
            string verifCode = RandomString(10);

            string orderNumber = $"{dto.Email}_{RandomString(5)}";

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ПетШопСаратов", "near55@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", dto.Email));
            emailMessage.Subject = "Бронирование на сайте PetShop";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Номер заказа: {orderNumber} {Environment.NewLine}" +
                $"Заказ: {dto.Count} ед. {_repo.GetItems().Where(x => x.ID == dto.ItemId).Select(x => x.Name).FirstOrDefault()} {Environment.NewLine}" +
                $"Код подтверждения: {verifCode}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync("near55@yandex.ru", "ckzdcftngdprnmmm");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            return Ok(new { VerifCode = verifCode, OrderNumber = orderNumber });
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
