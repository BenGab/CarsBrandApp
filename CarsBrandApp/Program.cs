using CarsBrand.DataAccess.CodeFirst;
using CarsBrand.Repository.Repository;
using CarsBrands.Repostiitroy.Repository;
using Carsdbrands.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsBrandApp
{    
    public static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
        {
            Console.WriteLine("*** BEGIN " + str);
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*** END " + str);
            Console.ReadLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var ctx = new CarsCFDbContext())
            {
                ICarService carsSevice = new CarService(new CarRepository(ctx), new BrandRepositroy(ctx));
                //ctx.Brands.Select(x => x.Name).ToConsole("BRANDS");
                carsSevice.GetAllCars().Select(x=> $"{x.Model} from {x.Brand.Name}").ToConsole("MODELS");

                var brandAverage = carsSevice.GetAveragebyBrand();

                brandAverage.ToConsole("Average brands");
            }
        }
    }
}
