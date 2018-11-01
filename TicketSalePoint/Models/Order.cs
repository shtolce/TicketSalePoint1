using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class Order
    {
        public int id {
            get;
            set;
        }
        public DateTime OrderDate {
            get;
            set;
        }
        public double InitialCost {
            get;
            set;
        }
        public string Comments {
            get;
            set;
        }
        public TicketEmission Emission {
            get;
            set;
        }
        public List<User> Customers {
            get;
            set;
        }
        public List<Ticket> SoldTickets;


        public static double CalculateAnOrderCostStatic() {
            return 500;
        }
        public double CalculateAnOrderCostDynamic() {
            return 500;
        }



    }
}
