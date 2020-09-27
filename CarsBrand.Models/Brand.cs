using System.Collections.Generic;

namespace CarsBrand.Models
{
    public class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
