using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries.ProductQueries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public GetProductQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
