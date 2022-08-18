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

    [HttpPut("process-ticket")]
    public async Task<ActionResult> ProcessTicketAsync(ProcessTicketDTO p)
    {
        bool isSuccess = await this._bus.ProcessTicketAsync(p);

        if (!isSuccess) return NotFound("Unable to process ticket.");

        return Created($"/tickets/{p.TicketID}", p);
    }

    [HttpGet("my-tickets")]
    public async Task<ActionResult> GetMyTicketsAsync(Guid? employeeID, string? filterStatusBy, string? filterTypeBy)
    {
        List<Ticket>? myTickets = await this._bus.GetMyTicketsAsync(employeeID, filterStatusBy, filterTypeBy);

        if (myTickets == null) return NotFound("Unable to find user.");
        
        if (myTickets.Count() == 0) return Ok("No tickets found.");

        return Ok(myTickets);
    }

    [HttpPut("change-role")]
    public async Task<ActionResult> ChangeEmployeeRole(ChangeRoleDTO c)
    {
        bool isSuccess = false;

        if(c.NewRole == "Manager") 
        {
            isSuccess = await this._bus.PromoteEmployee(c.RoleChangingEmployeeID, c.ProcessingManagerID, c.NewManagerID);
        }

        if(c.NewRole == "Employee")
        {
            isSuccess = await this._bus.DemoteManager(c.RoleChangingEmployeeID, c.ProcessingManagerID, c.NewManagerID);
        }

        if (!isSuccess) return NotFound("Could not make changes to employee");

        return Created($"/{c.RoleChangingEmployeeID}", c.NewRole);
    }

    [HttpPut("{ticketID}/upload/receipt-photo")]
    public async Task<ActionResult> UploadReceiptPhoto(IFormFile imageFile, Guid ticketID)
    {
        long fileLength = imageFile.Length;

        if (fileLength < 0)
        {
            return BadRequest();
        }

        using Stream fileStream = imageFile.OpenReadStream();

        if (await this._bus.UploadReceiptPhoto(fileStream, ticketID))
        {
            return Created("{ticketID}/photo", imageFile);
        }

        return BadRequest();
    }

    [HttpGet("{ticketID}/receipt-photo")]
    public async Task<ActionResult> GetReceiptPhoto(Guid ticketID)
    {
        byte[]? receiptPhoto = await this._bus.GetReceiptPhoto(ticketID);

        if (receiptPhoto == null) return BadRequest();

        return File(receiptPhoto, "image/png");
    }

    [HttpPut("{employeeID}/upload-photo")]
    public async Task<ActionResult> UploadEmployeePhoto(IFormFile imageFile, Guid employeeID)
    {
        long fileLength = imageFile.Length;

        if (fileLength < 0)
        {
            return BadRequest();
        }

        using Stream fileStream = imageFile.OpenReadStream();

        if (await this._bus.UploadEmployeePhoto(fileStream, employeeID))
        {
            return Created("{ticketID}/photo", imageFile);
        }

        return BadRequest();
    }

    [HttpGet("{employeeID}/photo")]
    public async Task<ActionResult> GetEmployeePhoto(Guid employeeID)
    {
        byte[]? employeePhoto = await this._bus.GetEmployeePhoto(employeeID);

        if (employeePhoto == null) return BadRequest();

        return File(employeePhoto, "image/png");
    }

    [HttpPut("{employeeID}/update-info")]
    public async Task<ActionResult> UpdateEmployeeInfo(UpdateEmployeeDTO ueDTO, Guid employeeID)
    {
        UpdateEmployeeDTO? updatedEmployee = await this._bus.UpdateEmployeeInfo(ueDTO, employeeID);
        
        if (updatedEmployee == null) return NotFound();

        return Ok(updatedEmployee);
    }

}