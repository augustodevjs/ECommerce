using Amazon.S3;
using System.Text;
using Amazon.S3.Model;
using System.Text.Json;
using ECommerce.Domain.Entities;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.Application.Services;

public class StorageService : IStorageService
{
    private readonly IAmazonS3 _client;

    public StorageService(IAmazonS3 client)
    {
        _client = client;
    }

    public async Task SaveInvoice(Invoice invoice)
    {
        var prefix = $"{invoice.DocumentClient}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";
        var key = $"{prefix}/{Guid.NewGuid()}.json";

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_ECOMMERCE"),
            Key = key,
            ContentType = "application/json",
            InputStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(invoice)))
        };

        await _client.PutObjectAsync(putObjectRequest);
    }

    public async Task<byte[]> DownloadFile(string nameBucket, string fileKey)
    {
        MemoryStream? stream = null;

        var getObjectRequest = new GetObjectRequest
        {
            BucketName = nameBucket,
            Key = fileKey
        };

        var response = await _client.GetObjectAsync(getObjectRequest);

        if(response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            stream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(stream);
        }

        if (stream is null)
        {
            throw new FileNotFoundException("File not found");
        }

        return stream.ToArray();
    }
}
