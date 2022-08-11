using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Manager : Employee
    {
        public Manager(Employee employee, int newManager) : base(employee.Username, employee.Password, employee.Fname, employee.Lname, employee.Role, employee.Address, employee.Phone, employee.Photo, employee.employeeID, newManager, employee.DateCreated)
        {
            this.Role = "Manager";
        }
        
        public void ProcessTicket(Ticket ticket, string status)
        {
            if (ticket.Status == "Pending" && status == "Approved") 
            {
                ticket.Approve();
                Console.WriteLine($"Ticket has been {status.ToLower()}");
            }
            else if (ticket.Status == "Pending" && status == "Denied") 
            {
                ticket.Deny();
                Console.WriteLine($"Ticket has been {status.ToLower()}");
            }
            else Console.WriteLine($"Ticket has already been {ticket.Status.ToLower()}");
        }

        public Manager PromoteEmployee(Employee employee)
        {
            Manager manager = new Manager(employee);
            manager.Role = "Manager";
            return manager;
        }

        public Employee DemoteManager(Manager manager)
        {
            Employee employee = new Employee(manager);
            employee.Role = "Employee";
            return employee;
        }
    }
}