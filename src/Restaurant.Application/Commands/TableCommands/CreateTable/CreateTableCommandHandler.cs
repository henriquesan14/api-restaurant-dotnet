using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.TableCommands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTableCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(request);
            await _unitOfWork.Tables.AddAsync(table);
            await _unitOfWork.CompleteAsync();
            return table.Id;
        }
    }
}
