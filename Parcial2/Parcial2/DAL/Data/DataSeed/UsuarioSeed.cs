using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApI_Preparcial_II.Dal.Data.DataSeed
{
    public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new Usuario
            {
                Id= 1,
                UserName = "user1",
                Password ="123456",
                Nombre = "Emiliano Pilo",
                Email = "emi@gmail.com"
            }, new Usuario
            {
                Id= 2,
                UserName = "user2",
                Password = "654321",
                Nombre = "USuario 2",
                Email = "usuario@gmail.com"
            },
            new Usuario
            {
                Id= 3,
                UserName = "user3",
                Password = "123456",
                Nombre = "Usuario 3",
                Email = "usuario3@gmail.com"
            });
        }
    }
}
