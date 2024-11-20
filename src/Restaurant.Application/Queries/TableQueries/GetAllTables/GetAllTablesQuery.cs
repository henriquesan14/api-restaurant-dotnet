using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Enums;
using System.Collections.Generic;

namespace Restaurant.Application.Queries.TableQueries.GetAllTables
{
    public class GetAllTablesQuery : IRequest<Result<List<TableViewModel>>>
    {
        public TableStatusEnum? TableStatus { get; set; }

        public GetAllTablesQuery(TableStatusEnum? tableStatus)
        {
            TableStatus = tableStatus;
        }
    }
}
