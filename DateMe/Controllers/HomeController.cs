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

            return View("DatingApplication", new Application());
        }
        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            if(ModelState.IsValid)
            {
                _context.Applications.Add(response); // add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            } 
            else // invalid data
            {
                ViewBag.Majors = _context.Majors
                    .OrderBy(x => x.MajorName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult WaitList() 
        {
            //Linq
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Applications
                .Single(x => x.ApplicationID == id);

            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.ApplicationID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application deleteInfo)
        {
            _context.Applications.Remove(deleteInfo);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

    }
}
