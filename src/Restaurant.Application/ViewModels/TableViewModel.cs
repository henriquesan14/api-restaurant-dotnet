using Restaurant.Core.Enums;

namespace Restaurant.Application.ViewModels
{
    public class TableViewModel
    {
        public int Id;
        public string Name { get; set; }
        public TableStatus Status { get; set; }
    }
}
