using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSalePoint.Models
{
    public class SalePoint
    {
        public int id { get; set; }
        public string address { get; set; }
        public User manager { get; set; }
        public void getCurrentQuantity(TicketEmission emission) {


        }
        public TicketEmission getEmission(DateTime begDateTime, DateTime endDateTime,List<TicketEmission> emissionsSet) {
            return null;
        }

        public static int sellTicket(ref TicketEmission emission, ApplicationUser user, int place)
        {
            emission.ticketsSet.Where<Ticket>(t=>t.place==place).First().isSold = true;
            emission.currentQuantity--;
            return 10;
        }
        public static int reserve(TicketEmission emission, ApplicationUser user, int place)
        {
            return 0;
        }
        public ApplicationUser addUser(string firstName,string coName,string address,Card card) {
            return new ApplicationUser();
        }



    }
}
