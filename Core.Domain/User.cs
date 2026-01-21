namespace Core.Domain
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}
