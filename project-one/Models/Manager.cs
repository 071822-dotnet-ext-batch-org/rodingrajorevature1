using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Manager : Employee
    {
        public Manager(Employee employee, int? newManager) : base(
            employee.Username, 
            employee.Password, 
            employee.Fname, 
            employee.Lname, 
            employee.Role,
            employee.Address, 
            employee.Phone, 
            employee.Photo, 
            employee.EmployeeID, 
            newManager, 
            employee.DateCreated, 
            employee.DateModified
        )
        {
            this.ChangeRole("Manager");
        }
        
        public void ProcessTicket(Ticket ticket, string newStatus)
        {
            if (ticket.Status == "Pending" && newStatus == "Approved") 
            {
                ticket.Approve();
                Console.WriteLine($"Ticket has been {newStatus.ToLower()}");
            }
            else if (ticket.Status == "Pending" && newStatus == "Denied") 
            {
                ticket.Deny();
                Console.WriteLine($"Ticket has been {newStatus.ToLower()}");
            }
            else Console.WriteLine($"Ticket has already been {ticket.Status.ToLower()}");
        }

        public Manager PromoteEmployee(Employee employee, Manager newManager)
        {
            Manager manager = new Manager(employee, newManager.EmployeeID);
            manager.ChangeRole("Manager");
            return manager;
        }

        public Employee DemoteManager(Manager manager, Manager newManager)
        {
            Employee employee = new Employee(
                manager.Username, 
                manager.Password, 
                manager.Fname, 
                manager.Lname,
                manager.Role,
                manager.Address, 
                manager.Phone, 
                manager.Photo, 
                manager.EmployeeID, 
                newManager.EmployeeID, 
                manager.DateCreated, 
                manager.DateModified
            );
            employee.ChangeRole("Employee");
            return employee;
        }
    }
}