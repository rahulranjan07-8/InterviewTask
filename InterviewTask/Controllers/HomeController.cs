using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InterviewTask.Models;
using System.Linq;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private static List<Person> persons = new List<Person>();

        public IActionResult Index()
        {
            return View(persons);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = persons.Count + 1;
                persons.Add(person);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = persons.FirstOrDefault(p => p.Id == person.Id);
                if (existingPerson != null)
                {
                    existingPerson.Name = person.Name;
                    existingPerson.Email = person.Email;
                    existingPerson.Phone = person.Phone;
                    existingPerson.Address = person.Address;
                    existingPerson.State = person.State;
                    existingPerson.City = person.City;
                    existingPerson.Agree = person.Agree;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                persons.Remove(person);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetPerson(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            return Json(person);
        }
    }
}
