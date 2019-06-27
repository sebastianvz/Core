using System;
using System.Collections.Generic;
using System.Text;
using ServiciosRepositorio;
using DTOs;

namespace Reglas
{
    public class UserRule : IUserRule
    {
        private readonly IuserService _service;
        public UserRule(IuserService _service)
        {
            this._service = _service;
        }

        public void Save(userDTO dto)
        {
            //_service.Save(dto);
        }

        public List<userDTO> GetAll()
        {
            return _service.Get();
        }

    }
}
