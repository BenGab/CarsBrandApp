using CarsBrand.DataAccess.CodeFirst;
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
                ctx.Brands.Select(x => x.Name).ToConsole("BRANDS");
                ctx.Cars.Select(x=> $"{x.Model} from {x.Brand.Name}").ToConsole("MODELS");

                var brandAverage = from car in ctx.Cars.Include(c => c.Brand)
                                   group car by new { car.Brand.Id, car.Brand.Name } into grp
                                   select new
                                   {
                                       BrandName = grp.Key.Name,
                                       AvPrice = grp.Average(c => c.BasePrice)
                                   };

                brandAverage.ToConsole("Average brands");
            }
        }
    }
}
