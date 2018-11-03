using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SkyAirlines.Models.Repositories;

namespace SkyAirlines.Models.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IManifestRepository Manifests { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Manifests = new ManifestRepository(_context);
        }

        public void EditRecord<TEntity>(TEntity entity, Expression<Func<TEntity, string>> predicate) 
            where TEntity : class
        {
            _context.Entry(entity).Property(predicate).IsModified = true;
        }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
