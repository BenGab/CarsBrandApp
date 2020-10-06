using CarsBrand.DataAccess.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarsBrand.Repository.Repository
{
    public class BrandRepositroy : BaseRepository<Brand>
    {
        public BrandRepositroy(DbContext dbContext) : base(dbContext)
        {
        }

        public override Brand GetByID(int Id)
        {
            return GetAll().Single(brand => brand.Id == Id);
        }

        public override void Update(Brand entity)
        {
            dbContext.Update(entity);
        }
    }
}
