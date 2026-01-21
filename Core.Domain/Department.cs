namespace Core.Domain
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public ICollection<User> users { get; set; }
    }
}
