using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.TableCommands.DeleteTable
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTableCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(request.Id);
            if(table == null)
            {
                return 0;
            }
            _unitOfWork.Tables.DeleteAsync(table);
            await _unitOfWork.CompleteAsync();
            return table.Id;
        }
    }
}
