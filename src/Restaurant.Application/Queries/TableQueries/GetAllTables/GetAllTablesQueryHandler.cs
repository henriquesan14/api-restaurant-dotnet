using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.TableQueries.GetAllTables
{
    public class GetAllTablesQueryHandler : IRequestHandler<GetAllTablesQuery, Result<List<TableViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTablesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<TableViewModel>>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Table, bool>> predicate = (t => t.Status == request.TableStatus || request.TableStatus == null);
            Func<IQueryable<Table>, IOrderedQueryable<Table>> orderBy = q => q.OrderBy(e => e.Name);

            var result = await _unitOfWork.Tables.GetAsync(predicate, orderBy, null, true);
            var viewModel = _mapper.Map<List<TableViewModel>>(result);
            return Result<List<TableViewModel>>.Success(viewModel);
        }
    }
}
