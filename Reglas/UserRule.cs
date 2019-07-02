using System;
using System.Collections.Generic;
using System.Text;
using ServiciosRepositorio;
using DTOs;

namespace Reglas
{
    public class UserRule : IUserRule
    {

        private readonly IpersonService _servicePerson;
        private readonly IuserService _service;
        public UserRule(IuserService _service, IpersonService _servicePerson)
        {
            this._service = _service;
            this._servicePerson = _servicePerson;
        }

        public void Save(userDTO dto)
        {
            int personID = _servicePerson.Create(dto.person);
            dto.IdPeson = personID;
            _service.Create(dto);
        }

        public List<userDTO> GetAll()
        {
            return _service.Get();
        }

    }
}
