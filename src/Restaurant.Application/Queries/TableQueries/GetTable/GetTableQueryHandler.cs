using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Errors;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Queries.TableQueries.GetTable
{
    public class GetTableQueryHandler : IRequestHandler<GetTableQuery, Result<TableViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTableQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<TableViewModel>> Handle(GetTableQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(request.Id);

            if (table == null) return Result<TableViewModel>.NotFound(string.Format(ErrorMessages.TABLE_NOT_FOUND, request.Id));

            var viewModel = _mapper.Map<TableViewModel>(table);

            return Result<TableViewModel>.Success(viewModel);
        }
    }
}
