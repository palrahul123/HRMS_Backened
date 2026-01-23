namespace Core.Domain
{
    public class Branch : BaseEntity
    {
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
