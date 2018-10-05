using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class TicketType   {
        public int id {
            get;
            set;
        }
        public DateTime begDate{
            get;
            set;
        }
        public DateTime endDate {
            get;
            set;
        }
        public DateTime begTime {
            get;
            set;
        }
        public DateTime endTime {
            get;
            set;
        }
        public string ticketName {
            get;
            set;
        }

    }
}
