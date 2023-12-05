using MediatR;

namespace Restaurant.Application.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
