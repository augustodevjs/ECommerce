using ECommerce.Domain.Entities;
using ECommerce.Domain.Contracts.Repository;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application.Services;

public class ProcessOrderPaidService : IProcessOrderPaidService
{
    private readonly IStorageService _service;
    private readonly IInvoiceRepository _repository;

    public ProcessOrderPaidService(
        IStorageService service,
        IInvoiceRepository repository
    )
    {
        _service = service;
        _repository = repository;
    }

    public async Task Process(Order order)
    {
        var invoice = new Invoice
        {
            DocumentClient = order.DocumentClient,
            InvoiceId = Guid.NewGuid().ToString(),
            TaxableBase = order.TotalValue,
            TaxRate = 20,
            Description = $"Invoice related to order {order.OrderId}"
        };

        await _service.SaveInvoice(invoice);
        await _repository.SaveInvoice(invoice);
    }
}