using System;
using System.Collections.Generic;
using System.Text;

namespace Carsdbrands.Logic.Models
{
    public class AverageResult
    {
        public string Name { get; set; }

        public decimal AveragePrice { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Avg: {AveragePrice}";
        }
    }
}
