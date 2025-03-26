using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>, IUpdatedByRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        
        public int UpdatedByUserId { get; set; }
    }
}
