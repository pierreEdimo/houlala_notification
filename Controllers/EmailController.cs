using Microsoft.AspNetCore.Mvc;


namespace notification_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{

    private readonly IEmailService _service;

    public EmailController(
        IEmailService service
    )
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult sendEmail([FromBody] EmailDto newEmail)
    {
        _service.sendStandardEmail(newEmail); 
        return Ok("Email Successful sent");
    }
}