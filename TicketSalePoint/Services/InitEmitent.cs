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
            if (db.TicketEmissions.Count() == 0)
            {
                TicketIssuer = new TicketIssuer();
                emission = TicketIssuer.createEmission(500, DateTime.Now, DateTime.Now.AddHours(3));
            }
            else {
                if (db.TicketEmissions.FirstOrDefault<TicketEmission>(t => t.endDateTime >= DateTime.Now).id!=0)
                    emission = db.TicketEmissions.FirstOrDefault(t => (t.endDateTime >= DateTime.Now));
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
                //currentTicketsSet = emission.ticketsSet.Where(p => p.place < 10).OrderByDescending(u=>u.id),
                // currentTicketsSet = emission.ticketsSet.Where(p => p.isSold).OrderByDescending(u => u.id),
                salesPoints = salePoints,
            };


        }




    }
}
