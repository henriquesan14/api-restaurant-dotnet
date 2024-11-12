using MediatR;
using Restaurant.Core.Enums;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.TableCommands.UpdateTable
{
    public class UpdateTableCommand : IRequest<int>, IUpdatedByRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TableStatusEnum Status { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
