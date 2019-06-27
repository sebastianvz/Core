using DTOs;
using System.Collections.Generic;

namespace ServiciosRepositorio
{
    public interface IuserService
    {
        void Create(userDTO dto);
        void Delete(int id);
        List<userDTO> Get();
        userDTO GetById(int id);
        void Update(userDTO dto);
    }
}