using DiscograficaWebApi.dto.Usuario;

namespace DiscograficaWebApi.Services.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDto> Create(UsuarioCreateRequestDto request);
        Task<UsuarioResponseDto> GetUsuarioByUserName(string username);
        Task<UsuarioResponseDto> Login(UsuarioLoginRequestDto request);
    }
}
