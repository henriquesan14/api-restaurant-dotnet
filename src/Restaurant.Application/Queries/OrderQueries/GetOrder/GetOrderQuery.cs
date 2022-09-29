﻿using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.OrderQueries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderViewModel>
    {
        public int Id { get; set; }

        public OrderType OrderType { get; set; }

        public GetOrderQuery(int id, OrderType orderType)
        {
            Id = id;
            OrderType = orderType;
        }
    }
}
