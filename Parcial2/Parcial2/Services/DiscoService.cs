using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.dto.Disco;
using DiscograficaWebApi.Entity;
using DiscograficaWebApi.Services.Interface;

namespace DiscograficaWebApi.Services;

public class DiscoService : IDiscoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DiscoService> _logger;

    public DiscoService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DiscoService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DiscoResponseDto> Create(DiscoCreateRequestDto request)
    {
        try
        {
            var disco = _mapper.Map<Disco>(request);
            await _unitOfWork.DiscoRepository.Add(disco);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al guardar el nuevo disco");
                throw new Exception("No se pudo guardar el nuevo disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            return discoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al crear disco");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByMasVendidos()
    {
        try
        {
            var discos = await _unitOfWork.DiscoRepository.GetTop5MasVendidos();
            if (discos.Count == 0)
            {
                _logger.LogError("Error, no hay discos vendidos");
                throw new Exception("No hay discos vendidos");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al obtener los discos mas vendidos");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<DiscoFilterResponseDto>> GetByFilter(DiscoFilterRequestDto request)
    {
        try
        {
            var discos = await _unitOfWork.DiscoRepository.GetByFilter(request);
            if (discos.Count == 0)
            {
                _logger.LogWarning("No se encontraron discos con los filtros seleccionados");
                throw new Exception("No se encontraron discos con los filtros seleccionados");
            }

            var discosResponse = _mapper.Map<List<DiscoFilterResponseDto>>(discos);

            return discosResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al guardar el nuevo disco");
            throw new Exception(ex.Message);
        }
    }


    public async Task<DiscoResponseDto> Update(string SKU, DiscoUpdateRequestDto request)
    {
        try
        {
            var disco = await _unitOfWork.DiscoRepository.GetBySKU(SKU);
            if (disco == null)
            {
                _logger.LogError("Error, el disco no existe");
                throw new Exception("El disco no existe");
            }

            _mapper.Map(request, disco);

            _unitOfWork.DiscoRepository.Edit(disco);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al actualizar el disco");
                throw new Exception("No se pudo actualizar el disco");
            }

            var discoResponse = _mapper.Map<DiscoResponseDto>(disco);

            return discoResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al actualizar el disco");
            throw new Exception(ex.Message);
        }
    }
}
