using ProjectOneModels;
using RepoLayer;

namespace BusinessLayer;
public class Bus
{
    private Repo _repo = new Repo();
    private Employee? _loggedIn = null;
    public Employee? LoggedIn
    {
        get
        {
            return _loggedIn;
        }
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        Employee? e = await this._repo.GetEmployeeByUsernameAsync(username);
        if (e != null && e.Password == password)
        {
            _loggedIn = e;
            return true;
        }
        else return false;
    }

    public async Task<bool> RegisterNewUserAsync(Employee e)
    {
        e.EmployeeID = Guid.NewGuid();
        return await this._repo.InsertNewEmployeeAsync(e);
    }

    public async Task<bool> SubmitTicketAsync(Ticket t)
    {
        t.TicketID = Guid.NewGuid();
        return await this._repo.InsertNewTicketAsync(t);
    }

    public async Task<bool> ProcessTicketAsync(ProcessTicketDTO p)
    {
        Manager? m = new Manager((await this._repo.GetEmployeeByIDAsync(p.ProcessingManagerID)), null);
        Ticket? t = await this._repo.GetTicketByIDAsync(p.TicketID);

        if(m.Role != "Manager" || t?.Status != "Pending")
        {
            return false;
        }

        if(p.NewStatus == "Approved")
        {
            t.Approve();
        }
        else if(p.NewStatus == "Denied")
        {
            t.Deny();
        }
        else
        {
            return false;
        }

        // Update ticket in database
        bool isSuccess = await this._repo.UpdateTicketByIDAsync(t, m.EmployeeID);
        return isSuccess;
    }

    public async Task<List<Ticket>?> GetMyTicketsAsync(Guid? employeeID, string? filterStatusBy)
    {
        Employee? e = await this._repo.GetEmployeeByIDAsync(employeeID);
        
        if (e == null) return null;

        List<Ticket>? tickets = await this._repo.GetTicketsByEmployeeID(employeeID, filterStatusBy);

        return tickets;
    }
}
