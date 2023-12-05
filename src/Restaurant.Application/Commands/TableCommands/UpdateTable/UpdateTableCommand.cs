using MediatR;

namespace Restaurant.Application.Commands.TableCommands.UpdateTable
{
    public class UpdateTableCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
