namespace Core.Application.DTOs.StateDtos
{
    public class CreateStateDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
    }
}
