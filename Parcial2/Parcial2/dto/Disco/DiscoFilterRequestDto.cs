namespace DiscograficaWebApi.dto.Disco;

public class DiscoFilterRequestDto
{
    public string? Titulo { get; set; }
    public string? GeneroMusical { get; set; }
    public int? CantidadVendida { get; set; }
}
