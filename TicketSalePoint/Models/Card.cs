using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class Card   {
        public int id {
            get;
            set;
        }
        public int number {
            get;
            set;
        }
        public int cvv {
            get;
            set;
        }
        public string dateTo {
            get;
            set;
        }
    }
}
