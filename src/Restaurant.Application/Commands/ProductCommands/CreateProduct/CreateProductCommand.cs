using MediatR;

namespace Restaurant.Application.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
