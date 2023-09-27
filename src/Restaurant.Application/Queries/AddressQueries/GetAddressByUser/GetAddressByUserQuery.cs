using MediatR;
using Restaurant.Application.ViewModels;
using System.Collections.Generic;

namespace Restaurant.Application.Queries.AddressQueries.GetAddressByUser
{
    public class GetAddressByUserQuery : IRequest<List<AddressViewModel>>
    {
        public int UserId { get; set; }

        public GetAddressByUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
