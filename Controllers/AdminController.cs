using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentMockUp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentMockUp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IunitRepository repo;

        public AdminController(IunitRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Apartment()
        {
            var apartments = repo.GetAllApartments();
            return View(apartments);
        }

        public IActionResult ViewApartments(int id)
        {
            var apartment = repo.GetApartment(id);
            return View(apartment); 
        }

        public IActionResult UpdateApartment(int id)
        {
            apartment apartment = repo.GetApartment(id);

            if (apartment == null)
            {
                return View("ApartmentNotFound");
            }

            return View(apartment);

        }

        public IActionResult UpdateApartmentToDatabase(apartment apartment)
        {
            repo.UpdateApartment(apartment);

            return RedirectToAction("ViewApartments", new { id = apartment.id });

        }
        public IActionResult InsertApartment()
        {
            var apartment = repo.AssignCategory();
            return View(apartment);
        }

        public IActionResult InsertApartmentToDatabase(apartment apartmentToInsert)
        {
            repo.InsertApartment (apartmentToInsert);

            return RedirectToAction("apartment");
        }
        public IActionResult DeleteApartment(apartment apartment)
        {
            repo.DeleteApartment(apartment);

            return RedirectToAction("apartment");
        }
    }
}

