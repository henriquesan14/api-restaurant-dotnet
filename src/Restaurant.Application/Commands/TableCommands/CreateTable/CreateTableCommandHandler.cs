using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.TableCommands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, int>
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public CreateTableCommandHandler(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(request);
            await _tableRepository.AddAsync(table);
            return table.Id;
        }
    }
}
