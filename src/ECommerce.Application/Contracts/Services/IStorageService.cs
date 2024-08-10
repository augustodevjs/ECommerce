using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IStorageService
{
    Task SaveInvoice(Invoice invoice);
}