using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>, IUpdatedByRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
