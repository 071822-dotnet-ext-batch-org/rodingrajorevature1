using Microsoft.AspNetCore.Mvc;
using ProjectOneModels;
using BusinessLayer;

namespace APILayer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

[ApiController]
[Route("[controller]")]
public class EmployeeManagementSystemController : ControllerBase
{
    private Bus _bus = new Bus();
    private readonly ILogger<EmployeeManagementSystemController> _logger;

    public EmployeeManagementSystemController(ILogger<EmployeeManagementSystemController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync(LoginDTO login)
    {
        if(ModelState.IsValid)
        {
            return Accepted(await this._bus.LoginAsync(login.Username, login.Password));
        }
        else
        {
            return NotFound("Unable to login");
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterNewUserAsync(Employee e)
    {
        bool isSuccess = await this._bus.RegisterNewUserAsync(e);

        if (!isSuccess) return NotFound("Unable to create user.");

        return Created($"/employee/{e.EmployeeID}", e);
    }

    [HttpPost("submit-ticket")]
    public async Task<ActionResult> SubmitTicketAsync(Ticket t)
    {
        bool isSuccess = await this._bus.SubmitTicketAsync(t);

        if (!isSuccess) return NotFound("Unable to create ticket.");

        return Created($"/{t.FK_EmployeeID}/tickets/{t.TicketID}", t);
    }

    [HttpPost("process-ticket")]
    public async Task<ActionResult> ProcessTicketAsync(ProcessTicketDTO p)
    {
        bool isSuccess = await this._bus.ProcessTicketAsync(p);

        if (!isSuccess) return NotFound("Unable to process ticket.");

        return Created($"/{p.EmployeeTicket.FK_EmployeeID}/tickets/{p.EmployeeTicket.TicketID}", p.EmployeeTicket);
    } 
}