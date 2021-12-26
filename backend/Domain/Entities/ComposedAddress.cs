namespace Domain.Entities
{
    public class ComposedAddress
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Index { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int? Corps { get; set; }
        public int? Flat { get; set; }
    }
}
