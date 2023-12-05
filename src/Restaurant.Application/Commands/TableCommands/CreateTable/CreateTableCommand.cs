using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.TableCommands.CreateTable
{
    public class CreateTableCommand : IRequest<int>
    {
        public string Name { get; set; }
        public TableStatus Status { get; set; }
    }
}
