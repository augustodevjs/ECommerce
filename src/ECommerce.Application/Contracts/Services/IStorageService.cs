using ECommerce.Domain.Entities;

namespace ECommerce.Application.Contracts.Services;

public interface IStorageService
{
    Task SaveInvoice(Invoice invoice);
    Task<byte[]> DownloadFile(string nameBucket, string fileKey);
}