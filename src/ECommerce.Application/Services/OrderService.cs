using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;
using ECommerce.Domain.Entities;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application.Services;

public class OrderService : IOrderService
{
    private readonly IAmazonSQS _sqsClient;

    public OrderService(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }

    public async Task SendOrder(Order order)
    {
        var request = new SendMessageRequest
        {
            MessageBody = JsonSerializer.Serialize(order),
            QueueUrl = Environment.GetEnvironmentVariable("ORDER_CREATED_SQS_URL")
        };

        await _sqsClient.SendMessageAsync(request);
    }
}
