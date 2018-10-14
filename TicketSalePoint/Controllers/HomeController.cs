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
using Microsoft.EntityFrameworkCore;
using TicketSalePoint.Models.dbcontexts;

namespace TicketSalePoint.Controllers
{
    public class HomeController : Controller
    {

        private InitEmitent _service;
        private TicketContext _db;

        public HomeController(InitEmitent service, TicketContext db) {
            this._service = service;
            this._db = db;
        }
            //        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
            public async Task<IActionResult> Index()
        {
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;//.Where(p => p.id<10).OrderByDescending(u => u.id);
            return View(_service.ivm);
        }

        //[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Sell(string name,int id,int curEmissionId)
        {
            int res;
            int rows,cols;

            //теперь в InitEmitent в _service.emission будет последняя по операции продажи эмиссия
            _service.emission = _db.TicketEmissions.FirstOrDefault(t => t.id == curEmissionId);
            res = SalePoint.sellTicket(ref _service.emission, new ApplicationUser(), id, curEmissionId);
            //-----
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;
            rows = _service.ivm.hallMapping.GetUpperBound(0) + 1;
            cols = _service.ivm.hallMapping.GetUpperBound(1) + 1;
            int row = (int)Math.Ceiling((double)id / cols) ;
            int col;
            int quiotent = Math.DivRem(id, cols, out col);
            col=(col==0)?6:col;
            _service.ivm.hallMapping[row-1,col-1 ]=1;
            _db.TicketEmissions.Include(t => t.ticketsSet).FirstOrDefault(t => t.id == _service.emission.id).ticketsSet[id-1].isSold = true;
            await _db.SaveChangesAsync();
            return View(_service.ivm);
        }


        public IActionResult SellForm(string name, int id, int curEmissionId)
        {
            _service.emission = _db.TicketEmissions.FirstOrDefault(t => t.id == curEmissionId);
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;
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
