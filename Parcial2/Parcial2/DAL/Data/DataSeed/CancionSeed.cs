using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApI_Preparcial_II.Dal.Data.DataSeed
{
    public class CancionSeed : IEntityTypeConfiguration<Cancion>
    {
        public void Configure(EntityTypeBuilder<Cancion> builder)
        {

            builder.HasData(new Cancion
            {
                Id = 1,
                Nombre = "Time",
                GeneroMusical = "Rock",
                Duracion = 420,
                FechaLanzamiento = new System.DateTime(1973, 3, 1),
                DiscoId = 1
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Money",
                GeneroMusical = "Rock",
                Duracion = 382,
                FechaLanzamiento = new System.DateTime(1973, 3, 1),
                DiscoId = 1
            },
            new Cancion
            {
                Id = 3,
                Nombre = "Us and Them",
                GeneroMusical = "Rock",
                Duracion = 462,
                FechaLanzamiento = new System.DateTime(1973, 3, 1),
                DiscoId = 1
            });
        }
    }
}
