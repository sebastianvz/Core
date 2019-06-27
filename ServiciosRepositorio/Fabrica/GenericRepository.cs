namespace ServiciosRepositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using DatosCore;
    public class GenericRepository<T> : IGenericRepository<T>, IGenericRepositoryAsync<T>
    where T : class
    {
        #region Properties
        private readonly DbContext _context;
        private IDbContextTransaction _transaction;
        #endregion

        #region Constructor
        protected GenericRepository(TestEFCoreContext contextApp)
        {
            _context = contextApp;
        }
        #endregion

        #region Public Methods               

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetAll(string includeProperties)
        {
            IQueryable<T> petition = _context.Set<T>();
            return IncludeProperties(petition, includeProperties).AsEnumerable();
        }

        public async Task<List<T>> GetAllAsync(string includeProperties)
        {
            IQueryable<T> petition = _context.Set<T>();
            return await IncludeProperties(petition, includeProperties).ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> function)
        {
            return _context.Set<T>().Where(function).AsEnumerable();
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> function)
        {
            return _context.Set<T>().Where(function).ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> function, string includeProperties)
        {
            IQueryable<T> petition = _context.Set<T>().Where(function);
            return IncludeProperties(petition, includeProperties).AsEnumerable();
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> function, string includeProperties)
        {
            IQueryable<T> petition = _context.Set<T>().Where(function);
            return IncludeProperties(petition, includeProperties).ToListAsync();
        }

        public T Add(T entidad)
        {
            _context.Set<T>().Add(entidad);
            return entidad;
        }

        public List<T> Add(List<T> entidad)
        {
            _context.Set<T>().AddRange(entidad);
            return entidad;
        }

        public void Delete(T entidad)
        {
            _context.Set<T>().Attach(entidad);
            _context.Set<T>().Remove(entidad);
        }

        public void Delete(List<T> entidad)
        {
            _context.Set<T>().AttachRange(entidad);
            _context.Set<T>().RemoveRange(entidad);
        }

        public void Edit(T entidad)
        {
            _context.Set<T>().Attach(entidad);
            _context.Entry(entidad).State = EntityState.Modified;
        }

        public void Edit(T entidad, T model)
        {
            _context.Entry(entidad).CurrentValues.SetValues(model);
            _context.Entry(entidad).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SatartTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }
        #endregion

        #region Private Method
        private IQueryable<T> IncludeProperties(IQueryable<T> petition, string includeProperties)
        {
            return includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).
                Aggregate(petition, (current, incluirPropiedad) => current.Include(incluirPropiedad));
        }
        #endregion
    }
}
