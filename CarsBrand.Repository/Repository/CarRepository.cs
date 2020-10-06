using CarsBrand.DataAccess.CodeFirst.Models;
using CarsBrand.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarsBrands.Repostiitroy.Repository
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Car GetByID(int Id)
        {
            return GetAll().Single(car => car.Id == Id);
        }

        public override void Update(Car entity)
        {
            dbContext.Update(entity);
        }
    }
}
