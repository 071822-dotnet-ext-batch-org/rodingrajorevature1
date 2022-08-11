using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Ticket : ITicket
    {
        public int TicketID { get; set; } = null;
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public byte[] Receipt { get; set; }
        public int FK_EmployeeID { get; set; }
        public int FK_ManagerID { get; set; }
        
        public Ticket(int amount, string description, string status, string type, int employeeID, int managerID)
        {
            this.Amount = amount;
            this.Description = description;
            this.Status = status;
            this.Type = type;
            this.FK_EmployeeID = employeeID;
            this.FK_ManagerID = managerID;
        }
    }
}