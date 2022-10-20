using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Codecool.CodecoolShop.Services;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

[Route("Checkout/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IMailService mailService;
    public MailController(IMailService mailService)
    {
        this.mailService = mailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail()
    {
        try
        {
            await mailService.SendEmailAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
