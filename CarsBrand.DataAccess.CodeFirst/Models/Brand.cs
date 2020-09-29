using System.Collections.Generic;

namespace CarsBrand.DataAccess.CodeFirst.Models
{
    public class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
