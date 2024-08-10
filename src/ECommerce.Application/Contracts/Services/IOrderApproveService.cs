using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IOrderApproveService
{
    Task OrderApprove(Order order);
}
