using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class TicketIssuer  {

        public TicketEmission createEmission(double price) {
            return new TicketEmission(price);
        }

    }
}
