using MediatR;
using Restaurant.Core.Enums;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.TableCommands.CreateTable
{
    public class CreateTableCommand : IRequest<int>, ICreatedByRequest
    {
        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }
        public int Capacity { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
