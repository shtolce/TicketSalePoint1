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
            return new TicketEmission(300);//заглушка
        }

        public static int sellTicket(ref TicketEmission emission, ApplicationUser user, int place)
        {
            emission.ticketsSet.Where<Ticket>(t=>t.id==place).First().isSold = true;
            //emission.ticketsSet.First().price --;
            emission.begDateTime = DateTime.Now;
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
