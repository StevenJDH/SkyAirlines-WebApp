using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyAirlines.Models;
using SkyAirlines.Models.UnitOfWork;

namespace SkyAirlines.Controllers
{
    public class ManifestsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManifestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _unitOfWork.Manifests.GetManifestsWithAllExceptAircraft();

            return View(model);
        }

        public IActionResult Details(string fltPrefix, int fltID, int paxID)
        {
            Manifest manifest = _unitOfWork.Manifests.GetManifestWithAll(fltPrefix, fltID, paxID);

            if (manifest == null)
            {
                return NotFound();
            }

            return View(manifest);
        }
    }
}
