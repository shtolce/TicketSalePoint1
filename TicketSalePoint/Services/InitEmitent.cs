using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSalePoint.Models;
using TicketSalePoint.ViewModels;
using Microsoft.EntityFrameworkCore;
using TicketSalePoint.Models.dbcontexts;

namespace TicketSalePoint.Services
{
    public class InitEmitent
    {

        public TicketEmission emission;
        public TicketIssuer TicketIssuer;
        public List<SalePoint> salePoints;
        public IndexViewModel ivm;
        public InitEmitent(TicketContext db)
        {
            /*
            if (db.TicketEmissions.Count() == 0) {
                TicketIssuer = new TicketIssuer();
                emission = TicketIssuer.createEmission(500, DateTime.Now, DateTime.Now.AddHours(3));
            }
            else {
                if (db.TicketEmissions.FirstOrDefault(t => t.endDateTime >= DateTime.Now) != null)
                    emission = db.TicketEmissions.Include(t => t.ticketsSet).FirstOrDefault(t => (t.endDateTime >= DateTime.Now));
                else
                {
                    TicketIssuer = new TicketIssuer();
                    emission = TicketIssuer.createEmission(500, DateTime.Now, DateTime.Now.AddHours(3));
                }
            }
            */
            if (db.TicketEmissions.Count() == 0)
            {
                TicketIssuer = new TicketIssuer();
                emission = TicketIssuer.createEmission(500, new DateTime(2018,10,10,8,0,1), new DateTime(2018, 10, 10, 11, 0, 0));
                db.TicketEmissions.Add(emission);
                emission = TicketIssuer.createEmission(500, new DateTime(2018, 10, 11, 0, 0, 1), new DateTime(2018, 10, 10, 5, 0, 0));
                db.TicketEmissions.Add(emission);
                emission = TicketIssuer.createEmission(500, new DateTime(2018, 10, 11, 5, 0, 1), new DateTime(2018, 10, 10, 17, 0, 0));
                db.TicketEmissions.Add(emission);
                emission = TicketIssuer.createEmission(500, new DateTime(2018, 10, 11, 17, 0, 1), new DateTime(2018, 10, 10, 23, 59, 59));
                db.TicketEmissions.Add(emission);
                db.SaveChanges();
            }



            salePoints = new List<SalePoint>() {
                new SalePoint() {
                    id=1,
                    address="ул. Кирова 8 б"
                },
                new SalePoint() {
                    id=2,
                    address="ул.Красногвардейская 18/2"
                }
            };

            ivm = new IndexViewModel
            {
                currentTicketsEmission = emission,
                TicketsEmissions = db.TicketEmissions,
                //currentTicketsSet = emission.ticketsSet.Where(p => p.place < 10).OrderByDescending(u=>u.id),
                // currentTicketsSet = emission.ticketsSet.Where(p => p.isSold).OrderByDescending(u => u.id),
                salesPoints = salePoints,
            };


        }




    }
}
