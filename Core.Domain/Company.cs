namespace Core.Domain
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public string PinCode { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }

}
