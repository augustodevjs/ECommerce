using ECommerce.Domain.Enums;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Contracts.Repository;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application.Services;

public class OrderApproveService : IOrderApproveService
{
    private readonly IMessageService _service;
    private readonly IOrderRepository _repository;

    public OrderApproveService(
        IMessageService service,
        IOrderRepository repository
    )
    {
        _service = service;
        _repository = repository;
    }

    public async Task OrderApprove(Order order)
    {
        if (order == null)
        {
            throw new Exception("Order cannot be null");
        }

        order.StatusOrder = StatusOrderEnum.PENDING_SHIPPING;

        await _repository.SaveOrder(order);
        await _service.SendMessage(order);
    }
}