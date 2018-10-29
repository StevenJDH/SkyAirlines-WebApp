using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyAirlines.Models;

namespace SkyAirlines.Controllers
{
    public class ManifestsController : Controller
    {
        private readonly AppDbContext _context;

        public ManifestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // The Includes are to eager load the navigation properties.
            var model = _context.Manifests
                .Include(m => m.Flight)
                .Include(m => m.Flight.Airport)
                .Include(m => m.Passenger)
                .OrderBy(m => m.Passenger.LastName)
                .ToList();

            return View(model);
        }
    }
}
