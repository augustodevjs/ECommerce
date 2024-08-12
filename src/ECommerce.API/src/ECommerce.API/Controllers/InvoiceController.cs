using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IStorageService _service;

    public InvoiceController(IStorageService service)
    {
        _service = service;
    }

    [HttpGet("download/{document}/{year}/{month}/{day}/{invoiceId}")]
    public async Task<IActionResult> DownloadInvoice(string document, string year, string month, string day, string invoiceId)
    {
        var fileKey = $"{document}/{year}/{month}/{day}/{invoiceId}.json";
        var fileName = fileKey.Replace("/", "-");

        var objectS3 = await _service.DownloadFile("invoice-bucket-ecommerce", fileKey);

        return File(objectS3, "application/octet-stream", fileName);
    }
}
