namespace Restaurant.Core.Entities.Base
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
