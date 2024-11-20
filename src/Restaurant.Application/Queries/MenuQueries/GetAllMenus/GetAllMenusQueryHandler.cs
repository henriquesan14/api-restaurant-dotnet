using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.MenuQueries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, Result<List<MenuViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMenusQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<MenuViewModel>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Menu, bool>> predicate = c =>
                (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower()));
            var list = await _unitOfWork.Menus.GetAsync(predicate);

            var viewModel = _mapper.Map<List<MenuViewModel>>(list);
            return Result<List<MenuViewModel>>.Success(viewModel);
        }
    }
}
