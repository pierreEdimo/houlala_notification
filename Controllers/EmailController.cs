using Microsoft.AspNetCore.Mvc;


namespace notification_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController(IEmailService service) : ControllerBase
{
    [HttpPost]
    public IActionResult SendEmail([FromBody] EmailDto newEmail)
    {
        service.SendStandardEmail(newEmail); 
        return Ok("Email Successful sent");
    }
}