using CarsBrand.DataAccess.CodeFirst.Models;
using Carsdbrands.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carsdbrands.Logic
{
    public interface ICarService
    {
        ICollection<Car> GetAllCars();

        ICollection<AverageResult> GetAveragebyBrand();
    }
}
