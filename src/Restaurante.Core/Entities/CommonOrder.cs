namespace Restaurant.Core.Entities
{
    public class CommonOrder : Order
    {
        public virtual Table Table { get; set; }
        public int? TableId { get; set; }

        public virtual User CreatedByUser { get; set; }
    }
}
