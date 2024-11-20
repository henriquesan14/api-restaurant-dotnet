using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;

namespace Restaurant.Application.Queries.TableQueries.GetTable
{
    public class GetTableQuery : IRequest<Result<TableViewModel>>
    {
        public int Id { get; set; }

        public GetTableQuery(int id)
        {
            Id = id;
        }
    }
}
