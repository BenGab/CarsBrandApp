namespace CarsBrand.Models
{
    public class Car
    {
        public int Id { get; set; }

        public virtual Brand Brand { get; set; }

        public string Model { get; set; }

        public decimal BasePrice { get; set; }

        public int  BrandId { get; set; }
    }
}
