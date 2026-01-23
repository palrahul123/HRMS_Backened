namespace Core.Domain
{
    public class Designation : BaseEntity
    {
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string ActiveLocation { get; set; }
    }
}
