using CarsBrand.DataAccess.CodeFirst.Models;
using CarsBrands.Repostiitroy.Repository;
using Carsdbrands.Logic;
using Carsdbrands.Logic.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CarsBrandsApp.Logic.uTest
{
    [TestFixture]
    public class CarServiceTest
    {
        private ICarService carService;
        private Mock<IRepository<Car>> carRepositoryMock;
        private Mock<IRepository<Brand>> brandRepositoryMock;

        [OneTimeSetUp]
        public void Setup()
        {
            carRepositoryMock = new Mock<IRepository<Car>>();
            brandRepositoryMock = new Mock<IRepository<Brand>>();
            carService = new CarService(carRepositoryMock.Object, brandRepositoryMock.Object);
        }

        [Test]
        public void GetAllCars_Should_Return_Expected_Cars()
        {
            //Arrange
            List<Car> cars = new List<Car>()
            {
                 new Car() { Id = 1, BrandId = 1, BasePrice = 20000, Model = "BMW 116d" },
                new Car() { Id = 2, BrandId =1, BasePrice = 30000, Model = "BMW 510" },
                new Car() { Id = 5, BrandId = 2, BasePrice = 20000, Model = "Audi A3" },
                new Car() { Id = 6, BrandId = 2, BasePrice = 25000, Model = "Audi A4" }
            };

            carRepositoryMock.Setup(carRepo => carRepo.GetAll()).Returns(cars.AsQueryable());

            var result = carService.GetAllCars();
            CollectionAssert.AreEqual(result, cars);
        }

        [Test]
        public void GetAllCars_returns_null_Should_Fail()
        {
            carRepositoryMock.Setup(carRepo => carRepo.GetAll()).Returns<IQueryable<Car>>(null);
            var result = carService.GetAllCars();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetAvaregaResult_Should_Returns_Expected()
        {
            List<Car> cars = new List<Car>()
            {
                 new Car() { Id = 1, BrandId = 1, BasePrice = 20000, Model = "BMW 116d" },
                new Car() { Id = 2, BrandId = 1, BasePrice = 30000, Model = "BMW 510" },
                new Car() { Id = 5, BrandId = 2, BasePrice = 20000, Model = "Audi A3" },
                new Car() { Id = 6, BrandId = 2, BasePrice = 25000, Model = "Audi A4" }
            };

            List<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                    Id = 1,
                    Name = "BMW"
                },

                new Brand()
                {
                    Id = 2,
                    Name = "Audi"
                }
            };

            List<AverageResult> expectedResult = new List<AverageResult>()
            {
                new AverageResult()
                {
                    Name = "BMW",
                    AveragePrice = 25000
                },

                new AverageResult()
                {
                    Name = "Audi",
                    AveragePrice = 22500
                },
            };

            carRepositoryMock.Setup(carRepo => carRepo.GetAll()).Returns(cars.AsQueryable());
            brandRepositoryMock.Setup(brandRepo => brandRepo.GetAll()).Returns(brands.AsQueryable());

            var result = carService.GetAveragebyBrand();

            Assert.That(result.Count, Is.EqualTo(expectedResult.Count));

            foreach(var item in result)
            {
                Assert.That(expectedResult.Where(avg => avg.Name == item.Name && avg.AveragePrice == item.AveragePrice).Single(), Is.Not.Null);
            }

        }
    }
}
