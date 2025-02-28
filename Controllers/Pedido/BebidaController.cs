using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Pedido;
using Server.Services.Token;
using Server.Services.User;

namespace Server.Controllers.Pedido;

[Route("/bebida")]
[ApiController]
public class BebidaController(IBebidaService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBebida([FromBody] BebidaData data)
    {
        var bebida = await service.CreateBebida(data);
        return Ok(bebida);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBebida([FromRoute] Guid Id)
    {
        var bebida = await service.DeleteBebida(Id);
        if(bebida is false)
            return NotFound("Drink not found!");

        return Ok("Drink deleted succesfully");
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetBebidaById([FromRoute] Guid Id)
    {
        var bebida = await service.GetBebidaById(Id);

        if (bebida is null)
            return NotFound("Drink not found!");
        
        return Ok(bebida);
    }

    [HttpGet]
    public async Task<IActionResult> GetBebidas()
    {
        var bebidas = await service.GetBebidas();

        return Ok(bebidas);
    }
}