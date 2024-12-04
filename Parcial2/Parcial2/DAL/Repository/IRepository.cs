namespace DiscograficaWebApi.DAL.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(long id);
    Task Add(T entity);
    void Edit(T entity);
    void Delete(T entity);
}
