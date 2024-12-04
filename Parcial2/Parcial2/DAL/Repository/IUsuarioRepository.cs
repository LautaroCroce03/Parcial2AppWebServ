using DiscograficaWebApi.Entity;

namespace DiscograficaWebApi.DAL.Repository;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> GetByUserName(string username);
}
