using SkyAirlines.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IManifestRepository Manifests { get; }

        int Complete();
    }
}
