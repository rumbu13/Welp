using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Welp.Web.Data;
using Welp.Web.Models.PageViewModels;

namespace Welp.Web.Controllers
{

    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        //dependency injection pe context
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(new HomeViewModel(_context));
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
            return View();
        }
    }
}
