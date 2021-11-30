using CleanArchitecture.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.Configuration
{
    // Configuração das própriedades da tabela, definimos chave primaria, relacionamento, se são obrigatorias e tipos das propriedades
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products"); // nome da tabela( se não colocar ele pega o nome que esta no DbSet)

            builder.HasKey(x => x.Id); // chave primaria           

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime") // tipo
                .IsRequired(); // obrigatorio

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(150)") // tipo e tamanho
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(400)")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)") // tipo com casas decimais
                .IsRequired();

        }
    }
}
