using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TicketSalePoint.Models
{
    public class TicketEmission   {
        const int CURRENT_QUANTITY = 30;
        public int id
        {
            get;
            set;
        }

        public List<Ticket> ticketsSet {
            get;
            set;
        }
        public double price {
            get;
            set;
        }
        public int currentQuantity {
            get;
            set;
        }
        public DateTime begDateTime {
            get;
            set;
        }
        public DateTime endDateTime {
            get;
            set;
        }
        public TicketEmission()
        {
        }
        public TicketEmission(double price, DateTime begDateTime, DateTime endDateTime) {
                this.ticketsSet = new List<Ticket>();
                for (int i = 1; i <= CURRENT_QUANTITY; i++)
                {
                    ticketsSet.Add(new Ticket(price, i, i));
                }
                this.price = price;
                this.currentQuantity = CURRENT_QUANTITY;
                this.begDateTime = begDateTime;
                this.endDateTime = endDateTime;
        }

    }
}
