using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ECommerce.Domain.Contracts.Repository;
using ECommerce.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infraestructure;

public static class DependecyInjection
{
    public static void AddDependeciesInfraestructure(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddAmazonDependecies();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    }

    private static void AddAmazonDependecies(this IServiceCollection services)
    {
        services.AddScoped<IDynamoDBContext, DynamoDBContext>();
        services.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
    }
}

