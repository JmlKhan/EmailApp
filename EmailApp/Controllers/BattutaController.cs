using EmailApp.Models;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattutaController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public BattutaController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public ActionResult CallMeRequest(Callme callme)
        {
            var message = new Message(new string[] { "info@battutatravel.uz" }, "New Lead\n", callme.Number,
                    callme.Name);

            _emailSender.SendEmail(message);
            return Ok();
        }

    }
}
