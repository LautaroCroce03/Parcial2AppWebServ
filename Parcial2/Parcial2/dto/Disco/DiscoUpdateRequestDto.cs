namespace DiscograficaWebApi.dto.Disco;

public class DiscoUpdateRequestDto
{
    public string Titulo { get; set; }
    public string GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public string? Banda { get; set; }
    public int CantidadVendida { get; set; }
}
