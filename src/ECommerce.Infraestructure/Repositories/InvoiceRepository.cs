using ECommerce.Domain.Entities;
using Amazon.DynamoDBv2.DataModel;
using ECommerce.Domain.Contracts.Repository;

namespace ECommerce.Infraestructure.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IDynamoDBContext _context;

    public InvoiceRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task SaveInvoice(Invoice invoice)
    {
        await _context.SaveAsync(invoice);
    }
}