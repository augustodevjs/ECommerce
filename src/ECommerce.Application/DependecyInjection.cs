using Amazon.S3;
using Amazon.SQS;
using ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application;

public static class DependecyInjection
{
    public static void AddDependeciesApplication(this IServiceCollection services)
    {
        services.AddServices();
        services.AddAmazonDependecies();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IOrderApproveService, OrderApproveService>();
        services.AddScoped<IProcessOrderPaidService, ProcessOrderPaidService>();
    }

    private static void AddAmazonDependecies(this IServiceCollection services)
    {
        services.AddScoped<IAmazonS3, AmazonS3Client>();
        services.AddScoped<IAmazonSQS, AmazonSQSClient>();
    }
}