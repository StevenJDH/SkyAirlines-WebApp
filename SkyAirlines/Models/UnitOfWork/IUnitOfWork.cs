using SkyAirlines.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SkyAirlines.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IManifestRepository Manifests { get; }

        void EditRecord<TEntity>(TEntity entity, Expression<Func<TEntity, string>> predicate) 
            where TEntity : class;

        int Complete();
    }
}
