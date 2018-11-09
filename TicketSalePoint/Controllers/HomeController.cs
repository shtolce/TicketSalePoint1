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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        //[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Index()
        {
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;//.Where(p => p.id<10).OrderByDescending(u => u.id);
            return View(_service.ivm);
        }
        
        //[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        [HttpGet]  //оставил для архива
        public async Task<IActionResult> Sell(string name,int id,int curEmissionId)
        {
            
            /*
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
            */
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Sell(int curEmId)
        {
            List<Ticket> res;
            int rows, cols;
            int adultsNum = Convert.ToInt32(Request.Form["kol"].ToString());
            int childrensNum = Convert.ToInt32(Request.Form["kolChildren"].ToString());
            List<User> ListCustomer=new List<User>();
            for (int i=0;i<=adultsNum-1;i++)
            {
                User Adult=new User();
                Adult.firstName = Request.Form["fio"][i];
                Adult.phoneNumber = Request.Form["phone"][i];
                Adult.isChildren = false;
                ListCustomer.Add(Adult);
            }

            for (int i = 0; i <= childrensNum-1; i++)
            {
                User Child = new User();
                Child.firstName = Request.Form["fioChildren"][i];
                Child.age = Convert.ToInt32(Request.Form["age"][i]);
                Child.isChildren = true;
                ListCustomer.Add(Child);
            }
            _service.emission = _db.TicketEmissions.FirstOrDefault(t => t.id == curEmId);
            res = SalePoint.sellTicket(ref _service.emission, adultsNum, childrensNum);
            _service.ivm.currentTicketsEmission = _service.emission;
            _service.ivm.currentTicketsSet = _service.emission.ticketsSet;
            Order singleOrder = new Order();
            singleOrder.Comments = "shtolce_test";
            singleOrder.Emission = _service.emission;
            singleOrder.Customers = ListCustomer;
            singleOrder.InitialCost = singleOrder.CalculateAnOrderCostDynamic();
            singleOrder.OrderDate = DateTime.Now;
            singleOrder.SoldTickets = res;
            _db.Orders.Add(singleOrder);
            _db.SaveChanges();
            _service.ivm.Orders.Add(singleOrder);
            rows = _service.ivm.hallMapping.GetUpperBound(0) + 1;
            cols = _service.ivm.hallMapping.GetUpperBound(1) + 1;
            int idx = 0;
            foreach (var ce in _service.emission.ticketsSet) {
                idx++;
                int row = (int)Math.Ceiling((double)idx / cols);
                int col;
                int quiotent = Math.DivRem(idx, cols, out col);
                col = (col == 0) ? 6 : col;
                _service.ivm.hallMapping[row - 1, col - 1] = Convert.ToInt32(ce.isSold);
                _db.TicketEmissions.Include(t => t.ticketsSet).
                    FirstOrDefault(t => t.id == _service.emission.id).
                    ticketsSet[idx - 1].isSold = ce.isSold;
                _db.SaveChanges();

            }
            ViewData["CurrentOrderId"] = singleOrder.id;
            return View(_service.ivm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
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
        [HttpGet]

        [Authorize(Roles = "admin")]
        public IActionResult OrderList()
        {
            ViewData["Message"] = "OrderList.";
            _service.ivm.Orders = _db.Orders.Include(t => t.Customers).ToList();
            return View(_service.ivm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult deleteOrder(int deleteOrder)
        {
            var order = _db.Orders.Include(t => t.Customers).Include(t=>t.SoldTickets).FirstOrDefault(t => t.id == deleteOrder);
            var orderWithoutJoints = _db.Orders.FirstOrDefault(t => t.id == deleteOrder);
            var ts = order.Emission.ticketsSet;
            var st = order.SoldTickets;
            //var tsIntersected = ts.Intersect(order.SoldTickets).ToList();
            //tsIntersected.ForEach(t => { t.isSold = false;t.price = 0; });
            st.ForEach(t => { t.isSold = false; t.price = 0; });
            //_db.Orders.Remove(orderWithoutJoints);
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return Redirect("~/Home/OrderList");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
