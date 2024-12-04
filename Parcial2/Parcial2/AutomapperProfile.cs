using AutoMapper;
using DiscograficaWebApi.dto.Cancion;
using DiscograficaWebApi.dto.Disco;
using DiscograficaWebApi.dto.Usuario;
using DiscograficaWebApi.Entity;

namespace DiscograficaWebApi;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Disco, DiscoResponseDto>()
            .ForMember(dest => dest.Canciones,
                    opt => opt.MapFrom(src => src.Canciones));
        CreateMap<DiscoCreateRequestDto, Disco>();
        CreateMap<DiscoUpdateRequestDto, Disco>();
        CreateMap<DiscoFilterRequestDto, Disco>();
        CreateMap<Disco, DiscoFilterResponseDto>()
            .ForMember(dest => dest.CantidadCanciones,
                    opt => opt.MapFrom(src => src.Canciones.Count));
        CreateMap<Cancion, CancionResponseDto>();
        CreateMap<CancionCreateRequestDto, Cancion>();
        CreateMap<CancionFilterRequestDto, Cancion>();
        CreateMap<Cancion, CancionFilterResponseDto>();
        CreateMap<Usuario, UsuarioResponseDto>();
        CreateMap<UsuarioCreateRequestDto, Usuario>();
    }
}
