using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.TableCommands.UpdateTable
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTableCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(request.Id);
            if (table == null)
            {
                return 0;
            }
            var tableEntity = _mapper.Map(request, table);
            _unitOfWork.Tables.UpdateAsync(tableEntity);
            await _unitOfWork.CompleteAsync();
            return tableEntity.Id;
        }
    }
}
