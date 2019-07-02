using System;
using DTOs;
using DatosCore;
using DatosCore.Models;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace ServiciosRepositorio
{
    public class personService: GenericRepository<Person>, IpersonService
    {
        #region Private Attributes
        private readonly IInclusion _inclusion;
        #endregion
        #region Constructor
        public personService(TestEFCoreContext contextApp, IInclusion _inclusion) : base(contextApp)
        {
            this._inclusion = _inclusion;
        }
        #endregion

        #region Public Methods

        #region Get
        public List<personDTO> Get()
        {
            return null;
        }

        public personDTO GetById(int id)
        {
            Person item = FindById(id);
            return Mapper.Map<Person, personDTO>(item);
        }

        #endregion

        public int Create(personDTO dto)
        {
            Person model = Mapper.Map<personDTO, Person>(dto);
            Add(model);
            Save();
            return model.Id;
        }

        public void Update(personDTO dto)
        {
            Person model = FindById(dto.Id);
            if (model == null) return;
            Edit(model, Mapper.Map<personDTO, Person>(dto));
            Save();
        }

        public void Delete(int id)
        {
            Person item = FindById(id);
            Delete(item);
            Save();
        }
        #endregion

        #region Private Methods
        private Person FindById(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
