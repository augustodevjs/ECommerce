using ECommerce.Domain.Entities;
using Amazon.DynamoDBv2.DataModel;
using ECommerce.Domain.Contracts.Repository;

namespace ECommerce.Infraestructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDynamoDBContext _context;

    public OrderRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task SaveOrder(Order order)
    {
        await _context.SaveAsync(order);
    }
}
