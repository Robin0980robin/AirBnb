namespace Infrastructure.Data.Configurations;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");
        builder.HasKey(d => d.Id);
        builder
            .Property(d => d.Nombre)
            .HasConversion(n => n.value, s => new Nombre(s))
            .HasColumnName("NombreDepartamento")
            .HasMaxLength(100)
            .IsRequired();
        // builder.OwnsOne(
        //     d => d.Precio,
        //     p =>
        //     {
        //         p.Property(dp => dp.value)
        //             .HasConversion(v => v, d=> new Dinero(d, Moneda.USD))
        //             .HasColumnName("PrecioValor")
        //             .HasColumnType("decimal(18,2)")
        //             .IsRequired();
        //         p.Property(dp => dp.Moneda.Codigo)
        //             .HasColumnName("PrecioMoneda")
        //             .HasMaxLength(3)
        //             .IsRequired();
        //     }
        // );
    }
}