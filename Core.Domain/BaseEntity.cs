using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
