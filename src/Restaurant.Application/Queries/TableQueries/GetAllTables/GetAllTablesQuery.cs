﻿using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Enums;
using System.Collections.Generic;

namespace Restaurant.Application.Queries.TableQueries.GetAllTables
{
    public class GetAllTablesQuery : IRequest<List<TableViewModel>>
    {
        public TableStatus? TableStatus { get; set; }

        public GetAllTablesQuery(TableStatus? tableStatus)
        {
            TableStatus = tableStatus;
        }
    }
}
