using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>, ICreatedByRequest
    {
        public string Name { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
