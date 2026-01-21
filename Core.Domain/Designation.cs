namespace Core.Domain
{
    public class Designation : BaseEntity
    {
        public string DesignationName { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public string ActiveLocation { get; set; }
    }
}
