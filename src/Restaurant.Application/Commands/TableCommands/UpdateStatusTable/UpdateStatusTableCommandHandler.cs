using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Errors;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.TableCommands.UpdateStatusTable
{
    public class UpdateStatusTableCommandHandler : IRequestHandler<UpdateStatusTableCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatusTableCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateStatusTableCommand request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(request.Id);
            if (table == null) return Result<TableViewModel>.NotFound(string.Format(ErrorMessages.TABLE_NOT_FOUND, request.Id));

            table.UpdateStatus(request.Status);

            await _unitOfWork.CompleteAsync();

            return Result.NoContent();
        }
    }
}
