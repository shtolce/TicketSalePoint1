using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class Ticket   {
        public int id {
            get;
            set;
        }
        public int type {
            get;
            set;
        }
        public bool isReserved {
            get;
            set;
        }
        public bool isSold
        {
            get;
            set;
        } = false;
        public double price {
            get;
            set;
        }
        public ApplicationUser manager {
            get;
            set;
        }
        public ApplicationUser customer {
            get;
            set;
        }
        public int place {
            get;
            set;
        }
        public int OrderId {
            get;
            set;
        }

        public Ticket() {
        }

        public Ticket(double price,int id,int place) {
            this.price = price;
        //    this.id = id;
            this.place = place;
        }


    }
}
