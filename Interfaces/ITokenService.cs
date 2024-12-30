using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}