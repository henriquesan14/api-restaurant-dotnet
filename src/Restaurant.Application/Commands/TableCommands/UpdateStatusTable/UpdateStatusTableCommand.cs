using MediatR;
using Restaurant.Core.Common;
using Restaurant.Core.Enums;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.TableCommands.UpdateStatusTable
{
    public class UpdateStatusTableCommand : IRequest<Result>, IUpdatedByRequest
    {
        public int Id { get; set; }
        public TableStatusEnum Status { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
