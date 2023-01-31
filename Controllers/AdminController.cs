using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}

