using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DatingApplicationContex _context;

        public HomeController(DatingApplicationContex temp) // constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DatingApplication()
        {
            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View();
        }
        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            _context.Applications.Add(response); // add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult WaitList() 
        {
            //Linq
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName).ToList();

            return View(applications);
        }

        public IActionResult Edit()
        {
            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication");
        }
    }
}
