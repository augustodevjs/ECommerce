using Microsoft.AspNetCore.Mvc;
using ECommerce.Domain.Entities;
using ECommerce.Application.Contracts.Services;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetClient(string document)
    {
        var client = await _service.Get(document);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(Client client)
    {
        await _service.Add(client);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClient(Client client)
    {
        await _service.Update(client);
        return Ok();
    }

    [HttpDelete("{document}")]
    public async Task<IActionResult> DeleteClient(string document)
    {
        await _service.Delete(document);
        return Ok();
    }
}
