using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}
