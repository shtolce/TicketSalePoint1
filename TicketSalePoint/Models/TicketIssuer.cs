using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class TicketIssuer
    {
    public int id { get; set; }

        public TicketEmission createEmission(double price, DateTime begDateTime, DateTime endDateTime) {
            return new TicketEmission(price, begDateTime, endDateTime);
        }

    }
}
