using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Configuration;
using Server.Services.Token;
using Server.Services.User;

namespace Server.Controllers;

[Route("/user")]
[ApiController]

public class UserController(IUserService service, ConfigurationManager config, ITokenService tokenService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AccountData accountData)
    {
        await service.CreateUser(accountData);
        return Ok("User created succesfully");
    }

    [Authorize]
    [HttpGet("invitation")]
    public IActionResult GetInvitationUrl()
    {
        var id = User.GetId();

        if(id is null)
            return Unauthorized();

        var localhost = config.GetClientUrl();
        return Ok($"{localhost}/user/invitation/{id}");
    }

    [HttpPost("invitation/{invite}")]
    public async Task<IActionResult> CreateUserWithInvite([FromRoute] Guid invite, [FromBody] AccountData accountData)
    {
        await service.CreateUser(accountData, invite);
        return Ok("User created succesfully");
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Login([FromBody] LoginData loginData)
    {
        var user = await service.Authenticate(loginData);
        if (user is null)
            return Unauthorized();

        var jwt = tokenService.Generate(user);
        return Ok(new{jwt});

    }
}