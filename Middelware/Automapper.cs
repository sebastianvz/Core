using System;
using DatosCore;
using DTOs;
using AutoMapper;
using DatosCore.Models;

namespace Middelware
{
    public class Automapper
    {
        void init()
        {
            Mapper.Initialize(config =>
            {
                //inversion de control
                config.CreateMap<User, userDTO>().ReverseMap();
            }
            );
        }
    }
}
