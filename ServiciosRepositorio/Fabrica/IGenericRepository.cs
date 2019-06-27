namespace ServiciosRepositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    public interface IGenericRepository<T>
    where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string includeProperties);
        IEnumerable<T> Find(Expression<Func<T, bool>> function);
        IEnumerable<T> Find(Expression<Func<T, bool>> function, string includeProperties);
        T Add(T entidad);
        List<T> Add(List<T> entidad);
        void Delete(T entidad);
        void Delete(List<T> entidad);
        void Edit(T entidad);
        void Save();

        void SatartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
