namespace Core.Domain
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<UserRole> userRoles { get; set; }
    }
}
