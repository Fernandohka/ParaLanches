using Server.Entities;
using Server.Models;

namespace Server.Services.User;

public interface IUserService 
{
    Task<ApplicationUser> CreateUser(AccountData data);
    Task<ApplicationUser> CreateUser(AccountData data, Guid invitedByUserId);
    Task<ApplicationUser> Authenticate(LoginData data);
}