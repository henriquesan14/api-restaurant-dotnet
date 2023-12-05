using MediatR;

namespace Restaurant.Application.Commands.TableCommands.DeleteTable
{
    public class DeleteTableCommand : IRequest<int>
    {
        public DeleteTableCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
