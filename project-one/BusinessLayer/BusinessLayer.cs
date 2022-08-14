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

    public async Task<Employee?> RegisterNewUserAsync(
        string username, 
        string password, 
        string fname, 
        string lname, 
        string role,
        string address, 
        string phone
    )
    {
        Employee e = new Employee(
            username, 
            password,
            fname, 
            lname, 
            role, 
            address, 
            phone,
            null,
            null,
            null,
            null,
            null
        );

        if (await this._repo.InsertNewEmployeeAsync(e))
        {
            return await this._repo.GetEmployeeByUsernameAsync(e.Username);
        }
        else 
        {
            return null;
        }
    }

    public async Task<Ticket?> SubmitTicketAsync(Ticket t)
    {
        if (await this._repo.InsertNewTicketAsync(t))
        {
            // return this._repo.GetNewestTicketFromEmployee(this.LoggedIn);
            return t;
        }
        else 
        {
            return null;
        }
    }
}
