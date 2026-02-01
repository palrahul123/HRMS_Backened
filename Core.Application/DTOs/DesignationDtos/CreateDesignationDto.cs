namespace Core.Application.DTOs.DesignationDtos
{
    public class CreateDesignationDto
    {
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public string ActiveLocation { get; set; }
    }
}
