using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.AddressQueries.GetAddressByUser
{
    public class GetAddressByUserQueryHandler : IRequestHandler<GetAddressByUserQuery, List<AddressViewModel>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressByUserQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<List<AddressViewModel>> Handle(GetAddressByUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _addressRepository.GetAddressByUser(request.UserId);
            var viewModel = _mapper.Map<List<AddressViewModel>>(result);
            return viewModel;
        }
    }
}
