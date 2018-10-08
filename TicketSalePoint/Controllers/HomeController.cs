using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSalePoint.Models;
using TicketSalePoint.ViewModels;
using System.Web;
using TicketSalePoint.Services;
namespace TicketSalePoint.Controllers
{
    public class HomeController : Controller
    {

        private readonly InitEmitent _service;

        public HomeController(InitEmitent service) {
            this._service = service;

        }
            //        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
            public IActionResult Index()
        {
            //ivm.currentTicketsSet = emission.ticketsSet.Where(p => p.isSold == true).OrderByDescending(u => u.id);
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;//.Where(p => p.id<10).OrderByDescending(u => u.id);
            return View(_service.ivm);
        }

        //        [HttpGet]
 //       [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Sell(string name,int id)
        {
            int res;
            int rows,cols;
            res =SalePoint.sellTicket(ref _service.emission, new ApplicationUser(), id);
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;
            rows = _service.ivm.hallMapping.GetUpperBound(0) + 1;
            cols = _service.ivm.hallMapping.GetUpperBound(1) + 1;
            int row = (int)Math.Ceiling((double)id / cols) ;
            int col;
            int quiotent = Math.DivRem(id, cols, out col);
            col=(col==0)?6:col;
            _service.ivm.hallMapping[row-1,col-1 ]=1;
            return View(_service.ivm);
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
