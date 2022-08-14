using ProjectOneModels;
using RepoLayer;

namespace BusinessLayer;
public class Bus
{
    private Repo _repo = new Repo();
    public async Task<bool> LoginAsync(string username, string password)
    {
        Employee? e = await this._repo.GetEmployeeByUsernameAsync(username);
        if (e != null && e.Password == password)
        {
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
        
        int isSuccess = await this._repo.InsertNewEmployeeAsync(e);

        if(isSuccess == 1)
        {
            return e;
        }
        else
        {
            return null;
        }
    }
}
