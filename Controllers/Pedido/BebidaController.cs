using Microsoft.AspNetCore.Mvc;
using Server.Services.Token;
using Server.Services.User;

namespace Server.Controllers.Pedido;

[Route("/bebida")]
[ApiController]
public class BebidaController(IUserService service, ConfigurationManager config, ITokenService tokenService) : ControllerBase
{
    
}
