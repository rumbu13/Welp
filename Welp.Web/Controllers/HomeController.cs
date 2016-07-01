using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Welp.Web.Data;

namespace Welp.Web.Controllers
{
    public class HomeView : ViewResult
    {
        public string Greeting
        {
            get
            {
                if (DateTime.Now.Hour < 3)
                    return "Bună seara";
                else if (DateTime.Now.Hour < 12)
                    return "Bună dimineața";
                else if (DateTime.Now.Hour < 18)
                    return "Bună ziua";
                else
                    return "Bună seara";
            }
        }
    }


    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

            
        }

        public IActionResult Index()
        {

            var tagLinesCount = _context.TagLines.Count();

            var selectedTagLine = _context.TagLines.Skip(new Random().Next(tagLinesCount - 1)).First().Text;

            ViewData["TagLine"] = selectedTagLine;

            

            return View(new HomeView());
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
