using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSalePoint.Models;
namespace TicketSalePoint.Models.dbcontexts
{
    public class TicketContext: DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketEmission> TicketEmissions { get; set; }
        public DbSet<SalePoint> SalePoints { get; set; }
        public DbSet<TicketIssuer> TicketIssuers { get; set; }
        public DbSet<Order> Orders { get; set; }



        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
