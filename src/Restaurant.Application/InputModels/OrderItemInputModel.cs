namespace Restaurant.Application.InputModels
{
    public class OrderItemInputModel
    {
        public int? Quantity { get; set; }

        public int? MenuItemId { get; set; }

        public string? Observation { get; set; }
    }
}
