using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOneModels
{
    public class ProcessTicketDTO
    {
        public Ticket? EmployeeTicket;
        public Guid? ProcessingManagerID;
        public string? NewStatus;

        public ProcessTicketDTO() {}

        public ProcessTicketDTO(Ticket employeeTicket, Guid processingManagerID, string newStatus)
        {
            this.EmployeeTicket = employeeTicket;
            this.ProcessingManagerID = processingManagerID;
            this.NewStatus = newStatus;
        }
    }
}