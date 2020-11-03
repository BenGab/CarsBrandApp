using CarsBrand.DataAccess.CodeFirst.Models;
using CarsBrands.Repostiitroy.Repository;
using Carsdbrands.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Carsdbrands.Logic
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carsrepository;
        private readonly IRepository<Brand> brandsRepository;

        public CarService(IRepository<Car> carsrepository, IRepository<Brand> brandsRepository)
        {
            this.carsrepository = carsrepository;
            this.brandsRepository = brandsRepository;
        }

        public ICollection<Car> GetAllCars()
        {
            return carsrepository.GetAll()?.ToList() ?? new List<Car>();
        }

        public ICollection<AverageResult> GetAveragebyBrand()
        {
            var q1 = from car in carsrepository.GetAll()
                     join brand in brandsRepository.GetAll() 
                     on car.BrandId equals brand.Id
                   group car by new { brand.Id, brand.Name } into grp
                   select new AverageResult
                   {
                       Name = grp.Key.Name,
                       AveragePrice = grp.Average(c => c.BasePrice)
                   };

            return q1.ToList();
        }
    }
}
