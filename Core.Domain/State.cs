namespace Core.Domain
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
