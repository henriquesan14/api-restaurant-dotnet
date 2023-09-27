using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.TableQueries.GetAllTables
{
    public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, List<TableViewModel>>
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public GetAllTablesQueryHandler(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<List<TableViewModel>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
        {
            var result = await _tableRepository.GetAllTables(request.TableStatus);
            var viewModel = _mapper.Map<List<TableViewModel>>(result);
            return viewModel;
        }
    }
}
