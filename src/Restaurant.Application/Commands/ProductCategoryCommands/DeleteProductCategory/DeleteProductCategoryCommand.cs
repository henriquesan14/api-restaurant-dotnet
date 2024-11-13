using MediatR;

namespace Restaurant.Application.Commands.ProductCategoryCommands.DeleteCategory
{
    public class DeleteProductCategoryCommand : IRequest<int>
    {
        public DeleteProductCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
