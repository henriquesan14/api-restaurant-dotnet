using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommandHandler : IRequestHandler<CreateCommonOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommonOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = _mapper.Map<CommonOrder>(request);
            decimal valueTotal = 0; 
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.EmployeeId = request.EmployeeId;
            entity.Type = "Common";

            await _unitOfWork.BeginTransaction();

            var products = new List<Product>();
            foreach (var item in entity.Items)
            {
                item.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                item.CreatedAt = DateTime.Now;
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                products.Add(product);
                valueTotal += product.Price * item.Quantity;
            }
            
            entity.ValueTotal = valueTotal;

            var table = await _unitOfWork.Tables.GetByIdAsync(entity.TableId.Value);
            table.Status = Core.Enums.TableStatusEnum.BUSY;
            _unitOfWork.Tables.UpdateAsync(table);
            await _unitOfWork.CompleteAsync();

            var result = await _unitOfWork.Orders.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();
            return result.Id;
        }
    }
}
