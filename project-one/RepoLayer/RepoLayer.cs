using dotenv.net;
using System.Data.SqlClient;

namespace RepoLayer;

public class Repo
{

    public void Connect()
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 3));
        IDictionary<string, string> envVars = DotEnv.Read();

        SqlConnection conn = new SqlConnection(envVars["CONNSTRING"]);

        SqlCommand command = new SqlCommand("SELECT * FROM dbo.Employee", conn);
        conn.Open();
        SqlDataReader myReader = command.ExecuteReader();

        while (myReader.Read())
        {
            Console.WriteLine($"\t{myReader.GetInt32(0)}\t{myReader.GetString(1)}");
        }

        conn.Close();
    }
}

