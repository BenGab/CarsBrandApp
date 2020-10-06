using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsBrands.Repostiitroy.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetByID(int Id);

        IEnumerable<TEntity> Find(Func<TEntity, bool> filter);

        void Update(TEntity entity);

        void Dele(TEntity delete);

        void Commit();
    }
}
