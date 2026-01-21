namespace Core.Domain
{
    public class Branch : BaseEntity
    {
        public string BranchName { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Department> departments { get; set; }
    }
}
