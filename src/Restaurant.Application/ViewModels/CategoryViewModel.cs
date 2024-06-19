using Restaurant.Core.Enums;
using System;

namespace Restaurant.Application.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryTypeEnum CategoryType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
