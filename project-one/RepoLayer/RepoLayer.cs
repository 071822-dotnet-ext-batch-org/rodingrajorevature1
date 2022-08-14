using dotenv.net;
using System.Data.SqlClient;
using ProjectOneModels;

namespace RepoLayer;

public class Repo
{
    private static readonly SqlConnection _conn = Repo._Connect();
    private static SqlConnection _Connect()
    {
        DotEnv.Load();
        IDictionary<string, string> envVars = DotEnv.Read();
        return new SqlConnection(envVars["CONNSTRING"]);
    }

    public void Test()
    {     
        SqlCommand command = new SqlCommand("SELECT * FROM dbo.Employee", _conn);
        _conn.Open();
        SqlDataReader myReader = command.ExecuteReader();

        while (myReader.Read())
        {
            Console.WriteLine($"\t{myReader.GetInt32(0)}\t{myReader.GetString(1)}");
        }

        _conn.Close();
    }

    public async Task<Employee?> GetEmployeeByUsernameAsync(string username)
    {
        int bufferSize = 100;
        byte[] outByte = new byte[bufferSize];

        SqlCommand command = new SqlCommand("SELECT * FROM dbo.Employee WHERE Username = @username", _conn);
        command.Parameters.AddWithValue("@username", username);
        _conn.Open();

        SqlDataReader? ret = await command.ExecuteReaderAsync();
        if (ret.Read())
        {
            Employee e = new Employee(
                ret.GetString(1),
                ret.GetString(2),
                ret.GetString(3),
                ret.GetString(4),
                ret.GetString(5),
                ret.GetString(6),
                ret.GetString(7),
                // ret.GetBytes(8, 0, outByte, 0, bufferSize),
                null,
                ret.GetInt32(0),
                // ret.GetInt32(9),
                null,
                ret.GetDateTime(10),
                ret.GetDateTime(11)
            );

            _conn.Close();
            return e;
        }
        else
        {
            _conn.Close();
            return null;
        }
    }

    public async Task<int> InsertNewEmployeeAsync(Employee e)
    {
        using (SqlCommand command = new SqlCommand("INSERT INTO Employee (Username, Password, Fname, Lname, Role, Address, Phone) VALUES (@username, @password, @fname, @lname, @role, @address, @phone)", _conn))
        {
            command.Parameters.AddWithValue("@username", e.Username);
            command.Parameters.AddWithValue("@password", e.Password);
            command.Parameters.AddWithValue("@fname", e.Fname);
            command.Parameters.AddWithValue("@lname", e.Lname);
            command.Parameters.AddWithValue("@role", e.Role);
            command.Parameters.AddWithValue("@address", e.Address);
            command.Parameters.AddWithValue("@phone", e.Phone);
            _conn.Open();
            int ret = await command.ExecuteNonQueryAsync();
            _conn.Close();
            return ret;
        };
    }
}

