using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.TableCommands.UpdateTable
{
    public class UpdateTableCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }
    }
}
