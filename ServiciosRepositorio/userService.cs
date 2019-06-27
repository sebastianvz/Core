using System;
using DTOs;
using DatosCore;
using DatosCore.Models;
using AutoMapper;

namespace ServiciosRepositorio
{
    public class userService : IuserService
    {
        public userService()
        {
        }

        public void Save(userDTO dto)
        {
            using (TestEFCoreContext db = new TestEFCoreContext())
            {
                db.User.Add(Mapper.Map<userDTO, User>(dto));
                db.SaveChanges();
            }
        }
    }
}
