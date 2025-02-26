using Server.Entities;

namespace Server.Services.Token;

public interface ITokenService{
    public string Generate(ApplicationUser user);
}