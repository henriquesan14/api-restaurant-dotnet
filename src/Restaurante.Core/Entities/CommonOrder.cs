namespace Restaurant.Core.Entities
{
    public class CommonOrder : Order
    {
        public Table Table { get; set; }
        public int TableId { get; set; }

        public User Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
