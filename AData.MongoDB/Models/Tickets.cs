using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.MongoDB.Models
{
    public class Tickets : Entity
    {
        public string StudentId { get; set; }

        public string BookId { get; set; }

        public string ManagerId { get; set; }

        public int OverDays { get; set; }

        public double TicketFee { get; set; }
    }
}
