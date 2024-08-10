using Xunit;
using System.Text.Json;
using ECommerce.Domain.Enums;
using Amazon.Lambda.SQSEvents;
using ECommerce.Domain.Entities;
using Amazon.Lambda.TestUtilities;

namespace ECommerce.ProcessOrderPaid.Tests;

public class FunctionTest
{
    [Fact]
    public async Task TestSQSEventLambdaFunction()
    {
        var address = new Address
        {
            Street = "123 Main St",
            Number = 456,
            Complement = "Apt 789",
            City = "Springfield",
            State = "IL"
        };

        var client = new Client
        {
            Document = "1234567890",
            Name = "John Doe",
            Email = "johndoe@example.com",
            Address = address
        };

        var orderItems = new List<OrderItem>
            {
                new() {
                    Quantity = 2,
                    UnitValue = 19.99m,
                    ProductId = 101
                },
                new() {
                    Quantity = 1,
                    UnitValue = 49.99m,
                    ProductId = 102
                }
            };

        var order = new Order
        {
            StatusOrder = StatusOrderEnum.PENDING_PAYMENT,
            OrderId = Guid.NewGuid(),
            Client = client,
            OrderItem = orderItems
        };

        var input = new SQSEvent
        {
            Records =
            [
                new SQSEvent.SQSMessage
                {
                    Body = JsonSerializer.Serialize(order),
                    Attributes = new Dictionary<string, string>()
                    {
                        { "ApproximateRecieveCount", "1" }
                    }
                }
            ]
        };

        var logger = new TestLambdaLogger();
        var context = new TestLambdaContext
        {
            Logger = logger
        };

        var function = new Function();
        await function.Handler(input, context);

        Assert.Contains($"Processed message {JsonSerializer.Serialize(order)}", logger.Buffer.ToString());
    }
}