using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}
