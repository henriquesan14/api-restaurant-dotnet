using Restaurant.Core.Enums;

namespace Restaurant.Application.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }
        public int Capacity { get; set; }
    }
}
