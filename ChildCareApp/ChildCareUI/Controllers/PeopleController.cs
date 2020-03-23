using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildCareApp;
using Microsoft.AspNetCore.Http;
using NToastNotify;

namespace ChildCareUI.Controllers
{
    public class PeopleController : Controller
    {

        private readonly IToastNotification _toastNotification;


        public PeopleController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        // GET: People
        public  IActionResult Index()
        {
            //return View(await _context.Persons.ToListAsync());
            return View(ChildCare.DispalyAllChildren());

        }

        // GET: People/Details/5
        public IActionResult Details(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = ChildCare.GetChildInfo(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,ClassName,PersonType")] Person person)
        {
            if (ModelState.IsValid)
            {
                ChildCare.CreatePerson(person.FirstName, person.LastName,person.ClassName, person.PersonType);
                _toastNotification.AddSuccessToastMessage("Child account created!"); 
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public IActionResult CreateActivity()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateActivity([Bind("Id,ActivityType,Description")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                ChildCare.createActivities(activity.Id, activity.ActivityType, activity.Description);
                 _toastNotification.AddSuccessToastMessage("Child Activities created!");
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: People/Edit/5
        public IActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = ChildCare.GetChildInfo(id.Value);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FirstName,LastName,ClassName,Status")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ChildCare.Update(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

         public IActionResult CheckIn(int? id)
        {
            var person = ChildCare.DailyCheckIn(id.Value);
            return View(person);
        }

        [HttpPost]
        public IActionResult CheckIn(IFormCollection controls)
        {
            var id = Convert.ToInt32(controls["Id"]);
            try
            {
                ChildCare.DailyCheckIn(id);
                return RedirectToAction(nameof(Index));
            }
            catch (FormatException)
            {
                _toastNotification.AddErrorToastMessage("CheckIn not completed!");
                ViewBag.ErrorMessage = "Invalid Child Id!";
                var person = ChildCare.DailyCheckIn(id);
                return View(person);

            }
        }
        public IActionResult CheckOut(int? id)
        {
            var person = ChildCare.DailyCheckOut(id.Value);
            return View(person);
        }

        [HttpPost]
        public IActionResult CheckOut(IFormCollection controls)
        {
            var id = Convert.ToInt32(controls["Id"]);
            try
            {
                ChildCare.DailyCheckOut(id);
                return RedirectToAction(nameof(Index));
            }
            catch (FormatException)
            {
                _toastNotification.AddErrorToastMessage("CheckOut not completed!");
                ViewBag.ErrorMessage = "Invalid Child Id!";
                var person = ChildCare.DailyCheckOut(id);
                return View(person);

            }
        }

        public IActionResult Activity(int? id)
        {
            var person = ChildCare.GetAllActivitiesById(id.Value);
            return View(person);
        }

        [HttpPost]
        public IActionResult Activity(IFormCollection controls)
        {
            var id = Convert.ToInt32(controls["Id"]);
            try
            {
                ChildCare.GetAllActivitiesById(id);
                return RedirectToAction(nameof(Index));
            }
            catch (FormatException)
            {
                _toastNotification.AddErrorToastMessage("Acitivites List not completed!");
                ViewBag.ErrorMessage = "Invalid Child Id!";
                var person = ChildCare.GetAllActivitiesById(id);
                return View(person);

            }
        }

       
        //private bool PersonExists(int id)
        //{
        //    return _context.Persons.Any(e => e.Id == id);
        //}


    }
}
