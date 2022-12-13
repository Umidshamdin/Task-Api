
namespace DomainLayer.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
