using DTOs;

namespace Reglas
{
    public interface IAuthorizationRule
    {
        AuthorizationDto Auth(LoginDto dto);
    }
}