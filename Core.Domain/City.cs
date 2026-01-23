namespace Core.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
