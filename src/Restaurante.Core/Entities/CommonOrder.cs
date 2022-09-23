namespace Restaurant.Core.Entities
{
    public class CommonOrder : Order
    {
        public Table Table { get; set; }

        public User Employee { get; set; }
    }
}
