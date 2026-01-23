namespace Core.Domain
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public int? RoleId { get; set; }
        public ICollection<UserRole>? userRoles { get; set; }
    }
}
