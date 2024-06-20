using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, int>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UpdateOrderItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.Orders.GetByIdAsync(request.OrderItemId);
            if (item == null)
            {
                return 0;
            }
            var itemUpdate = _mapper.Map(request, item);
            _unitOfWork.Orders.UpdateAsync(itemUpdate);
            await _unitOfWork.CompleteAsync();
            return item.Id;
        }
    }
}
