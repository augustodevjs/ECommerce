using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;
using ECommerce.Domain.Entities;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application.Services;

public class MessageService : IMessageService
{
    private readonly IAmazonSQS _sqsClient;

    public MessageService(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }

    public async Task SendMessage(Order order)
    {
        var request = new SendMessageRequest
        {
            MessageBody = JsonSerializer.Serialize(order),
            QueueUrl = Environment.GetEnvironmentVariable("ORDER_PAID_SQS_URL")
        };

        await _sqsClient.SendMessageAsync(request);
    }
}