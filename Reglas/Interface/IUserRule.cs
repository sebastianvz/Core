using System.Collections.Generic;
using DTOs;

namespace Reglas
{
    public interface IUserRule
    {
        void Save(userDTO dto);
        List<userDTO> GetAll();
    }
}