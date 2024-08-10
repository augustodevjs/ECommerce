using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Contracts.Repository;

public interface IInvoiceRepository
{
    Task SaveInvoice(Invoice invoice);
}

