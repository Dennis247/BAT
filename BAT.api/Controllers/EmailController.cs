using BAT.api.Authorization;
using BAT.api.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace BAT.api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [AllowAnonymous]
        [HttpGet("TestEmail")]
        public IActionResult TestEmail()
        {
            _emailService.SendEmailWithSendGrid(new Utils.Helpers.Message
            {
                To = new List<string> { "dosamuyimen@gmail.com" },
                Subject = "demo message",
                HtmlContent = "demo",
                PlainContent = "demo"
            });

            return Ok();
        }
    }
}
