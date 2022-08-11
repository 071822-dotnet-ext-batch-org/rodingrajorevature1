using RepoLayer;
using System.Data.SqlClient;

namespace APILayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Repo myRepo = new Repo();
            myRepo.Connect();
        }
    }
}