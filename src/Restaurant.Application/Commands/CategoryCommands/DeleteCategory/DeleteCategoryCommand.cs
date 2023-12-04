using MediatR;

namespace Restaurant.Application.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
