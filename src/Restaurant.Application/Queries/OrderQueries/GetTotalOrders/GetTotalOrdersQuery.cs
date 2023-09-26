using MediatR;
using Restaurant.Application.ViewModels;
using System;
namespace Restaurant.Application.Queries.OrderQueries.GetTotalOrders
{
    public class GetTotalOrdersQuery : IRequest<TotalOrderViewModel>
    {
        public GetTotalOrdersQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
