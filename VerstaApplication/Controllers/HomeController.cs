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
            ViewBag.DataManager = dataManager;
            return View(ViewBag.DataManager);
        }

        public IActionResult NewOrder()
        {
            Order entity = new Order();
            return View(entity);
        }

        [HttpPost]
        public IActionResult NewOrder(Order model)
        {
            if (ModelState.IsValid)
                dataManager.Orders.SaveOrder(model);

            ViewBag.DataManager = dataManager;
            return View("Index", ViewBag.DataManager);
        }
    }
}
