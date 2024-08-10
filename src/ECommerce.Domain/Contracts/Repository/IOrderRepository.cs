using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Contracts.Repository;

public interface IOrderRepository
{
    Task SaveOrder(Order order);
}