using MediatR;

namespace Restaurant.Application.Commands.TableCommands.DeleteTable
{
    public class DeleteTableCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
