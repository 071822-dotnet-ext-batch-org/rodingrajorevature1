using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Employee : IEmployee
    {
        public int EmployeeID { get; set; } = null;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Role { get; set; } = "Employee";
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public int ManagerID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Employee(string username, string password, string fname, string lname, string address, string phone, int managerID)
        {
            this.Username = username;
            this.Password = password;
            this.Fname = fname;
            this.Lname = lname;
            this.Address = address;
            this.Phone = phone;
            this.ManagerID = managerID;
        }
    }
}