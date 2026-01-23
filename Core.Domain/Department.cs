namespace Core.Domain
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Designation> Designations { get; set; }
    }
}
