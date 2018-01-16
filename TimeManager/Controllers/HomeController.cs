using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.Data;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var model = context.TimeSpending.Include(i => i.WorkerUser).Where(t => DateTime.Now.Date < t.CreateDate).ToList();
            return View(model);
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
