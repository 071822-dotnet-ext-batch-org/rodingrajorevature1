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
        Manager? m = await this._repo.GetEmployeeByIDAsync(p.ProcessingManagerID);
        
        if(m.Role != "Manager" || p.EmployeeTicket?.Status != "Pending")
        {
            return false;
        }

        if(p.NewStatus == "Approved")
        {
            p.EmployeeTicket.Approve();
        }
        else if(p.NewStatus == "Denied")
        {
            p.EmployeeTicket.Deny();
        }
        else
        {
            return false;
        }

        // Update ticket in database
        return true;
    }
}
