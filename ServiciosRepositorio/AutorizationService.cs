using System;
using System.Collections.Generic;
using System.Text;
using DatosCore;
using DatosCore.Models;
using DTOs;
using System.Linq;

namespace ServiciosRepositorio
{
    public class AutorizationService : GenericRepository<User>, IAutorizationService
    {

        public AutorizationService(TestEFCoreContext contextApp) : base(contextApp)
        {
        }

        public AuthorizationDto Autentication(LoginDto dto)
        {
            using (var db = new TestEFCoreContext())
            {
                var authentication = db.User
                    .Where(c => c.UserName == dto.UserName && c.Password == dto.Password)
                    .Select(n => new AuthorizationDto
                    {
                        UserId = n.Id,
                        Username = n.UserName
                    }
                    ).First();
                return authentication;
            }
        }
    }
}
