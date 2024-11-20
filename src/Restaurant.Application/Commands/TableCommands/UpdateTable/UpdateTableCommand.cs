using MediatR;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.TableCommands.UpdateTable
{
    public class UpdateTableCommand : IRequest<int>, IUpdatedByRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
