using DiscograficaWebApi.DAL.Repository;

namespace DiscograficaWebApi.DAL;

public interface IUnitOfWork : IDisposable
{
    IDiscoRepository DiscoRepository { get; }
    ICancionRepository CancionRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }
    Task<int> Save();
}
