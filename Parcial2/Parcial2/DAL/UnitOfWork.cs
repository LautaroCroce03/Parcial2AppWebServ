using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Repository;

namespace DiscograficaWebApi.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IDiscoRepository DiscoRepository { get; }
    public ICancionRepository CancionRepository { get; }
    public IUsuarioRepository UsuarioRepository { get; }

    public UnitOfWork(DataContext context, IDiscoRepository discoRepository, ICancionRepository cancionRepository, IUsuarioRepository usuarioRepository)
    {
        _context = context;
        DiscoRepository = discoRepository;
        CancionRepository = cancionRepository;
        UsuarioRepository = usuarioRepository;
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
