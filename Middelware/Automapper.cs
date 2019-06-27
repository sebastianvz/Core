using System;
using DatosCore;
using DTOs;
using AutoMapper;
using DatosCore.Models;

namespace Middelware
{
    public class Automapper
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                //inversion de control
                config.CreateMap<User, userDTO>().ReverseMap();
            });
        }
    }
}
