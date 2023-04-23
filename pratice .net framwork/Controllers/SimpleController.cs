using Microsoft.AspNetCore.Mvc;

namespace pratice_.net_framwork.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class SimpleController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello world!";
    }
}