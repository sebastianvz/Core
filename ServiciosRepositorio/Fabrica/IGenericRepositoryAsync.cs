namespace ServiciosRepositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public interface IGenericRepositoryAsync<T>
    where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(string includeProperties);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> function);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> function, string includeProperties);
        Task SaveAsync();
    }
}
