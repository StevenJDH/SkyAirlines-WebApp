using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SkyAirlines.Models.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Generic DbContext base class, not our AppDbContext.
        private readonly DbContext _context; 
        private readonly DbSet<TEntity> _entity;

        public Repository(DbContext context)
        {
            _context = context;
            // Gets a reference to the DbSet without our AppDbContext.
            _entity = _context.Set<TEntity>(); 
        }

        public TEntity GetRecord(int id) => _entity.Find(id);

        public IEnumerable<TEntity> GetAll() => _entity.ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => 
            _entity.Where(predicate);

        // Will return just the first result if more than one result is returned.
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => 
            _entity.FirstOrDefault(predicate);

        // Can throw an exception if more than one result is returned.
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            _entity.SingleOrDefault(predicate);

        public void Add(TEntity entity) => _entity.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _entity.AddRange(entities);

        public void Remove(TEntity entity) => _entity.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => _entity.RemoveRange(entities);
    }
}
