using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IOrderService
{
    Task SendOrder(Order order);
}
