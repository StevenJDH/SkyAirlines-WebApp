using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models.Repositories
{
    public sealed class ManifestRepository : Repository<Manifest>, IManifestRepository
    {
        private readonly AppDbContext _context;

        public ManifestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Manifest GetManifestWithAll(string fltPrefix, int fltID, int paxID)
        {
            return _context.Manifests
                .Include(m => m.Flight)
                .Include(m => m.Flight.Aircraft)
                .Include(m => m.Flight.Airport)
                .Include(m => m.Passenger)
                .FirstOrDefault(m =>
                    m.FlightPrefix == fltPrefix &&
                    m.FlightId == fltID &&
                    m.PassengerId == paxID
                );
        }

        public IEnumerable<Manifest> GetManifestsWithAllExceptAircraft()
        {
            // The Includes are to eager load the navigation properties.
            return _context.Manifests
                .Include(m => m.Flight)
                .Include(m => m.Flight.Airport)
                .Include(m => m.Passenger)
                .OrderBy(m => m.Passenger.LastName)
                .ToList();
        }
    }
}
