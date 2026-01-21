namespace Core.Domain
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public ICollection<Branch> branches { get; set; }
    }
}
