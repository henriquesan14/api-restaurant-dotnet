using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.ProductCategoryCommands.UpdateCategory
{
    public class UpdateProductCategoryCommand : IRequest<int>, IUpdatedByRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
