using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSalePoint.Models;
using TicketSalePoint.ViewModels;


namespace TicketSalePoint.Controllers
{
    public class HomeController : Controller
    {
        private TicketEmission emission;
        private TicketIssuer TicketIssuer;
        private List<SalePoint> salePoints;
        private IndexViewModel ivm;
        int l;
        public HomeController() {
            TicketIssuer = new TicketIssuer();
            emission = TicketIssuer.createEmission(500);
            l++;
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

            ivm = new IndexViewModel {
                currentTicketsEmission = emission,
                //currentTicketsSet = emission.ticketsSet.Where(p => p.place < 10).OrderByDescending(u=>u.id),
               // currentTicketsSet = emission.ticketsSet.Where(p => p.isSold).OrderByDescending(u => u.id),
                salesPoints = salePoints
            };
           

        }

        public IActionResult Index()
        {
            //ivm.currentTicketsSet = emission.ticketsSet.Where(p => p.isSold == true).OrderByDescending(u => u.id);
            ivm.currentTicketsEmission = emission;
            ivm.currentTicketsSet = emission.ticketsSet;//.Where(p => p.id<10).OrderByDescending(u => u.id);
            return View(ivm);
        }

//        [HttpGet]
        public IActionResult Sell(string name,int quantity)
        {
            int res;
            res=SalePoint.sellTicket(emission, new ApplicationUser(), 2);
            ivm.currentTicketsEmission = emission;
            ivm.currentTicketsSet = emission.ticketsSet;
            
            return View(ivm);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
