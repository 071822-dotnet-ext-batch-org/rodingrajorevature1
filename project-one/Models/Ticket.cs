using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class Ticket : ITicket
    {
        public Guid? TicketID { get; set; } = Guid.NewGuid();
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        private string? _status = "Pending";
        public string? Type { get; set; }
        public long? Receipt { get; set; }
        public Guid? FK_EmployeeID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateProcessed { get; set; }
        
        public Ticket() {}
        public Ticket(
            Guid? ticketID,
            decimal amount, 
            string description, 
            string type, 
            long? receipt,
            Guid employeeID, 
            DateTime? dateCreated, 
            DateTime? dateModified, 
            DateTime? dateProcessed
        )
        {
            this.TicketID = ticketID;
            this.Amount = amount;
            this.Description = description;
            this.Type = type;
            this.Receipt = receipt;
            this.FK_EmployeeID = employeeID;
            if (dateCreated!=null) this.DateCreated = dateCreated;
            if (dateModified!=null) this.DateModified = dateModified;
            if (dateProcessed!=null) this.DateProcessed = dateProcessed; 
        }

        public string? Status
        {
            get 
            {
                return this._status;
            }
        }
        public void Approve()
        {
            this._status = "Approved";
        }

        public void Deny()
        {
            this._status = "Denied";
        }
    }
}