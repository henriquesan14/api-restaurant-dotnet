using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand : IRequest<Result<ProductViewModel>>, ICreatedByRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int QuantityInStock { get; set; }

        public string UnitOfMeasure { get; set; }

        public int CategoryId { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
