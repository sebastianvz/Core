using System;
using DTOs;
using DatosCore;
using DatosCore.Models;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace ServiciosRepositorio
{
    public class userService: GenericRepository<User>, IuserService
    {
        #region Private Attributes
        private readonly IInclusion _inclusion;
        #endregion
        #region Constructor
        public userService(TestEFCoreContext contextApp, IInclusion _inclusion) : base(contextApp)
        {
            this._inclusion = _inclusion;
        }
        #endregion

        #region Public Methods

        #region Get
        public List<userDTO> Get()
        {
            _inclusion.AddInclusion(nameof(User.person));
            var items = Mapper.Map<List<User>, List<userDTO>>(GetAll(_inclusion.GetInclusions()).ToList());
            _inclusion.ClearInclusions();
            return items;
        }

        public userDTO GetById(int id)
        {
            User item = FindById(id);
            return Mapper.Map<User, userDTO>(item);
        }

        #endregion

        public void Create(userDTO dto)
        {
            User model = Mapper.Map<userDTO, User>(dto);
            Add(model);
            Save();
        }

        public void Update(userDTO dto)
        {
            User model = FindById(dto.Id);
            if (model == null) return;
            Edit(model, Mapper.Map<userDTO, User>(dto));
            Save();
        }

        public void Delete(int id)
        {
            User item = FindById(id);
            Delete(item);
            Save();
        }
        #endregion

        #region Private Methods
        private User FindById(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
