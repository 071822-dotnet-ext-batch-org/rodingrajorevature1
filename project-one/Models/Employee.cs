using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Employee : IEmployee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        private string _role { get; set; } = "Employee";
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[]? Photo { get; set; }
        public int? EmployeeID { get; set; }
        public int? ManagerID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public Employee(string username, string password, string fname, string lname, string address, string phone, byte[]? photo, int? employeeID, int? managerID, DateTime? dateCreated, DateTime? dateModified)
        {
            this.Username = username;
            this.Password = password;
            this.Fname = fname;
            this.Lname = lname;
            this.Address = address;
            this.Phone = phone;
            if (photo!=null) this.Photo = photo;
            if (employeeID!=null) this.EmployeeID = employeeID;
            if (managerID!=null) this.ManagerID = managerID;
            if (dateCreated!=null) this.DateCreated = dateCreated;
            if (dateModified!=null) this.DateModified = dateModified;
        }

        public string Role 
        {
            get 
            {
                return this._role;
            }
        }

        public void ChangeRole(string newRole)
        {
            this._role = newRole;
        }

    }
}