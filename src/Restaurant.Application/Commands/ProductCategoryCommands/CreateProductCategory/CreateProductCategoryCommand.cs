using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.ProductCategoryCommands.CreateCategory
{
    public class CreateProductCategoryCommand : IRequest<int>, ICreatedByRequest
    {
        public string Name { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
