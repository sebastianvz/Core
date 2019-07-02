using DTOs;
using System.Collections.Generic;

namespace ServiciosRepositorio
{
    public interface IpersonService
    {
        int Create(personDTO dto);
        void Delete(int id);
        List<personDTO> Get();
        personDTO GetById(int id);
        void Update(personDTO dto);
    }
}