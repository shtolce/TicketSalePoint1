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
        private TicketContext _db;
        public TicketEmission emission;
        public TicketIssuer TicketIssuer;
        public List<SalePoint> salePoints;
        public IndexViewModel ivm;
        private int PRICE = 300;

        public bool IsEmissionExist(DateTime begDate, DateTime endDate) {
            if (_db.TicketEmissions.FirstOrDefault(t => t.endDateTime >= endDate & t.begDateTime <= begDate) != null)
                return true;
            else
                return false;
        }

        public TicketEmission CreateEmission(double price, DateTime begDate, DateTime endDate) {
            TicketIssuer = new TicketIssuer();
            TicketEmission tE = TicketIssuer.createEmission(price, begDate, endDate);
            _db.TicketEmissions.Add(tE);
            _db.SaveChanges();
            return tE;
        }

        public TicketEmission GetEmission(DateTime begDate, DateTime endDate)
        {
            return _db.TicketEmissions.Include(t => t.ticketsSet).FirstOrDefault(t => t.endDateTime >= endDate & t.begDateTime <= begDate);
        }

        public InitEmitent(TicketContext db)
        {
            this._db = db;

            if (IsEmissionExist(new DateTime(2018, 10, 12, 0, 0, 1), new DateTime(2018, 10, 12, 6, 0, 0)))  
                 emission = GetEmission(new DateTime(2018, 10, 12, 0, 0, 1), new DateTime(2018, 10, 12, 6, 0, 0));
            else
            {
                emission = CreateEmission(PRICE, new DateTime(2018, 10, 12, 0, 0, 1), new DateTime(2018, 10, 12, 6, 0, 1));
            }

            if (IsEmissionExist(new DateTime(2018, 10, 12, 6, 0, 1), new DateTime(2018, 10, 12, 23, 0, 0)))
                emission = GetEmission(new DateTime(2018, 10, 12, 6, 0, 1), new DateTime(2018, 10, 12, 23, 0, 0));
            else
            {
                emission = CreateEmission(PRICE, new DateTime(2018, 10, 12, 6, 0, 1), new DateTime(2018, 10, 12, 23, 0, 0));
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
                currentTicketsEmission = emission
                ,TicketsEmissions = _db.TicketEmissions 
                ,salesPoints = salePoints
            };

            int rows, cols;
            rows = IndexViewModel.ROWS;
            cols = IndexViewModel.COLS;
            ivm.hallMappings.Clear();
            foreach (TicketEmission te in ivm.TicketsEmissions)
            {
                int[,] hallMapping = new int[rows, cols];
                for (int i = 0; i <= rows - 1; i++)
                {
                    for (int j = 0; j <= cols - 1; j++)
                    {
                        hallMapping[i, j] = _db.TicketEmissions.Include(t => t.ticketsSet).FirstOrDefault(t => t.id == te.id).ticketsSet[i * cols + j].isSold ? 1 : 0;
                    }
                }
                ivm.hallMappings.Add(te.id,hallMapping);
                
            }


        }




    }
}
