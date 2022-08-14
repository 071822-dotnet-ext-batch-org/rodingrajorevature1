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
    public async Task<ActionResult> LoginAsync(string username, string password)
    {
        return Accepted(await this._bus.LoginAsync(username, password));
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterNewUserAsync(
        string username, 
        string password, 
        string fname, 
        string lname, 
        string role,
        string address, 
        string phone
    )
    {
        Employee? e = await this._bus.RegisterNewUserAsync(
            username, 
            password,
            fname, 
            lname, 
            role, 
            address, 
            phone
        );

        if (e!=null) return Ok(e);
        else return NotFound("Unable to create user.");
    }

    [HttpPost("submit-ticket")]
    public async Task<ActionResult> SubmitTicketAsync(
        decimal amount,
        string description,
        string type,
        long? receipt
    )
    {
        // TESTING IF IT WORKST, CHANGE BACK TO != null after LoggedIn is fixed)
        if (this._bus.LoggedIn == null)
        {
            Ticket t = new Ticket(
                amount,
                description,
                type,
                receipt,
                1001,
                null,
                null,
                null
            );
            
            this._bus.SubmitTicketAsync(t);

            return Ok(t);
        }
        else
        {
            return NotFound("Please log in to create a ticket.");
        }
    }
}