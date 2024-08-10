using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IProcessOrderPaidService
{
    Task Process(Order order);
}

