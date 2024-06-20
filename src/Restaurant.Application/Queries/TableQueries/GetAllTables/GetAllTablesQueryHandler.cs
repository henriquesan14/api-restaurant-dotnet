using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.TableQueries.GetAllTables
{
    public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, List<TableViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTablesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TableViewModel>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Table, bool>> predicate = t => t.Status == request.TableStatus;
            var result = await _unitOfWork.Tables.GetAsync(predicate);
            var viewModel = _mapper.Map<List<TableViewModel>>(result);
            return viewModel;
        }
    }
}
