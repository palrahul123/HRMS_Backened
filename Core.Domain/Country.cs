namespace Core.Domain
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<State> States { get; set; } = new List<State>();


    }
}
