using ECommerce.Domain.Entities;
x'
namespace ECommerce.Application.Contracts.Services;
public interface IOrderApproveService
{
    Task OrderApprove(Order order);
}
