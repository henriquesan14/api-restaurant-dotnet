using MediatR;

namespace Restaurant.Application.Commands.ProductCommands.RemoveProduct
{
    public class DeleteProductCommand : IRequest<int>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
