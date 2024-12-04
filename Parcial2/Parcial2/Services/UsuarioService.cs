using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.dto.Usuario;
using DiscograficaWebApi.Entity;
using DiscograficaWebApi.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DiscograficaWebApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UsuarioService> logger, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<UsuarioResponseDto> Create(UsuarioCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("Se inicia el metodo de Create Usuario");

                var existingUser = await _unitOfWork.UsuarioRepository.GetByUserName(request.UserName);
                if (existingUser != null)
                {
                    _logger.LogWarning("El nombre de usuario ya existe");
                    throw new Exception("El nombre de usuario ya existe");
                }

                var usuario = _mapper.Map<Usuario>(request);
                await _unitOfWork.UsuarioRepository.Add(usuario);

                var result = await _unitOfWork.Save();
                if (result == 0)
                {
                    _logger.LogError("Error al guardar el nuevo usuario");
                    throw new Exception("No se pudo guardar el nuevo usuario");
                }

                var usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);

                _logger.LogInformation($"Usuario creado exitosamente. Id: {usuario.Id}");
                return usuarioResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioResponseDto> Login(UsuarioLoginRequestDto request)
        {
            try
            {
                _logger.LogInformation("Se inicia el método Login");

                var usuario = await _unitOfWork.UsuarioRepository.GetByUserName(request.UserName);
                if (usuario == null)
                {
                    _logger.LogWarning("No se encontró el usuario");
                    throw new Exception("No se encontró el usuario");
                }

                if (usuario.Password != request.Password)
                {
                    _logger.LogWarning("Contraseña incorrecta");
                    throw new Exception("Contraseña incorrecta");
                }

                var usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);

                usuarioResponse.Token = GenerateJwtToken(usuario);

                _logger.LogInformation($"Usuario logueado. Id: {usuario.Id}");
                return usuarioResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al loguear usuario");
                throw new Exception(ex.Message);
            }
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", usuario.Id.ToString()),
                new Claim("DisplayName", usuario.Nombre),
                new Claim("UserName", usuario.UserName),
                new Claim("Email", usuario.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UsuarioResponseDto> GetUsuarioByUserName(string username)
        {
            try
            {
                _logger.LogInformation("Se inicia el método GetUsuarioByUserName");

                var usuario = await _unitOfWork.UsuarioRepository.GetByUserName(username);
                if (usuario == null)
                {
                    _logger.LogWarning("No se encontró el usuario");
                    throw new Exception("No se encontró el usuario");
                }

                var usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);

                _logger.LogInformation($"Usuario encontrado. Id: {usuario.Id}");
                return usuarioResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar usuario");
                throw new Exception(ex.Message);
            }
        }
    }
}
