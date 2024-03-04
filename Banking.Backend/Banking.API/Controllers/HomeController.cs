using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Banking.API.Models;

namespace Banking.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }

}