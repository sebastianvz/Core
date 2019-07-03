using DTOs;

namespace ServiciosRepositorio
{
    public interface IAutorizationService
    {
        AuthorizationDto Autentication(LoginDto dto);
    }
}