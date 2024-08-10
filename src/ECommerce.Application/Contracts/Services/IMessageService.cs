using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IMessageService
{
    Task SendMessage(Order order);
}

