using System.Text.Json;
using Amazon.Lambda.Core;
using ECommerce.Application;
using Amazon.Lambda.SQSEvents;
using ECommerce.Domain.Entities;
using ECommerce.Application.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ECommerce.ProcessOrderPaid;
public class Function
{
    private readonly IProcessOrderPaidService _service;

    public Function()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDependeciesApplication();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        _service = serviceProvider.GetRequiredService<IProcessOrderPaidService>();
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
        context.Logger.LogInformation($"Processed message {message.Body}");

        var order = JsonSerializer.Deserialize<Order>(message.Body);

        await _service.Process(order);

        await Task.CompletedTask;
    }
}