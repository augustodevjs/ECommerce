using Amazon.DynamoDBv2.DataModel;

namespace ECommerce.Domain.Entities;

public class Client
{
    public string Document { get; set; }

    [DynamoDBProperty("Name")]
    public string Name { get; set; }

    [DynamoDBProperty("Email")]
    public string Email { get; set; }

    [DynamoDBProperty("Address")]
    public Address Address { get; set; }
}
