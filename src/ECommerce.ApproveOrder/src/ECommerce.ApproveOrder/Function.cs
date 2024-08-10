using System.Text.Json;
using Amazon.Lambda.Core;
using ECommerce.Application;
using Amazon.Lambda.SQSEvents;
using ECommerce.Infraestructure;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Application.Contracts.Services;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ECommerce.ApproveOrder;

public class Function
{
    private readonly IOrderApproveService _service;

    public Function()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDependeciesApplication();
        serviceCollection.AddDependeciesInfraestructure();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        _service = serviceProvider.GetRequiredService<IOrderApproveService>();
    }

    public async Task Handler(SQSEvent evnt, ILambdaContext context)
    {
        foreach (var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.Log("Message Serialized.");
        context.Logger.Log(JsonSerializer.Serialize(message));

        context.Logger.Log("ApproximateReceiveCount");
        context.Logger.Log(message.Attributes["ApproximateReceiveCount"]);

        context.Logger.Log("The message has been processed.");
        context.Logger.Log(message.Body);

        var order = JsonSerializer.Deserialize<Order>(message.Body);

        await _service.OrderApprove(order);

        await Task.CompletedTask;
    }
}