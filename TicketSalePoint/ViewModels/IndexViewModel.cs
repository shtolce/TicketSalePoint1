using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSalePoint.Models;

namespace TicketSalePoint.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Ticket> currentTicketsSet;
        public TicketEmission currentTicketsEmission;
        public IEnumerable<TicketEmission> TicketsEmissions;
        public IEnumerable<SalePoint> salesPoints;
        public static int ROWS = 5;
        public static int COLS = 6;

        public int[,] hallMapping ={
                                    {0,0,0,0,0,0 }
                                   ,{0,0,0,0,0,0 }
                                   ,{0,0,0,0,0,0 }
                                   ,{0,0,0,0,0,0 }
                                   ,{0,0,0,0,0,0 }
                                    };

        public Dictionary<int, int[,]> hallMappings = new Dictionary<int, int[,]>();

        public IndexViewModel() {





        }
    }
}
