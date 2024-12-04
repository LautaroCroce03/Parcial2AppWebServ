namespace DiscograficaWebApi.dto.Disco;

public class DiscoCreateRequestDto
{
    public string Titulo { get; set; }
    public string GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int CantidadVendida { get; set; } = 0;
    public string SKU { get; set; }
}
