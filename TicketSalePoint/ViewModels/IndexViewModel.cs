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
        public IEnumerable<SalePoint> salesPoints;

    }
}
