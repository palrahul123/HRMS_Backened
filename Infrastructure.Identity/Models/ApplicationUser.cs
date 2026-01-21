using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public bool IsActive { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}
