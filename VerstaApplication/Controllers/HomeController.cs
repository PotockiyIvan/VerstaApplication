using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaApplication.Domain.Entities;
using VerstaApplication.Domain.Repositories;

namespace VerstatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //var model = dataManager.Orders.GetOrders().OrderBy(x => x.OrderNumber);
            //return View(model);

            ViewBag.DataManager = dataManager;
            return View(ViewBag.DataManager);
        }

        public IActionResult NewOrder(Guid id)
        {
            Order entity = new Order();
            return View(entity);
        }
    }
}
