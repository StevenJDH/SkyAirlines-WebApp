using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models.Repositories
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        /// <summary>
        /// Gets a manifest record using a composite key with all eager-loaded navigation
        /// properties for Flight, Airport, Aircraft, and Passenger.
        /// </summary>
        /// <param name="fltPrefix">Flight prefix code</param>
        /// <param name="fltID">Flight ID for prefix code</param>
        /// <param name="paxID">Passenger ID associated with flight</param>
        /// <returns>Passenger manifest record if present otherwise returns null.</returns>
        Manifest GetManifestWithAll(string fltPrefix, int fltID, int paxID);

        /// <summary>
        /// Gets a flat collection of manifests with eager-loaded navigation properties 
        /// for Flight, Airport, and Passenger except for Aircraft.
        /// </summary>
        /// <returns>All manifests and navigation properites except Aircraft.</returns>
        IEnumerable<Manifest> GetManifestsWithAllExceptAircraft();
    }
}
