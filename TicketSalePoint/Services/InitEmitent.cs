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

        public void GetCreateEm(int year,int month,int day) 
        {

            if (IsEmissionExist(new DateTime(year, month, day, 11, 0, 0), new DateTime(year, month, day, 13, 59, 59)))  
                 emission = GetEmission(new DateTime(year, month, day, 11, 0, 0), new DateTime(year, month, day, 13, 59, 59));
            else
            {
                emission = CreateEmission(PRICE, new DateTime(year, month, day, 11, 0, 0), new DateTime(year, month, day, 13, 59, 59));
            }

            if (IsEmissionExist(new DateTime(year, month, day, 14, 0, 0), new DateTime(year, month, day, 16, 59, 59)))
                emission = GetEmission(new DateTime(year, month, day, 14, 0, 0), new DateTime(year, month, day, 16, 59, 59));
            else
            {
                emission = CreateEmission(PRICE, new DateTime(year, month, day, 14, 0, 0), new DateTime(year, month, day, 16, 59, 59));
            }

            if (IsEmissionExist(new DateTime(year, month, day, 17, 0, 0), new DateTime(year, month, day, 19, 59, 59)))
                emission = GetEmission(new DateTime(year, month, day, 17, 0, 0), new DateTime(year, month, day, 19, 59, 59));
            else
            {
                emission = CreateEmission(PRICE, new DateTime(year, month, day, 17, 0, 0), new DateTime(year, month, day, 19, 59, 59));
            }

        }


        public InitEmitent(TicketContext db)
        {
            this._db = db;
            for (int i=14;i<=30;i++)
            {
                GetCreateEm(2018, 12, i);
            }
            for (int i = 1; i <= 14; i++)
            {
                GetCreateEm(2019, 1, i);
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
                ,Orders = _db.Orders.ToList()
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
