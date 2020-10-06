using CarsBrands.Repostiitroy.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsBrand.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dele(TEntity delete)
        {
            dbContext.Remove(delete);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> filter)
        {
            return GetAll().Where(filter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        public abstract TEntity GetByID(int Id);

        public abstract void Update(TEntity entity);

    }
}
