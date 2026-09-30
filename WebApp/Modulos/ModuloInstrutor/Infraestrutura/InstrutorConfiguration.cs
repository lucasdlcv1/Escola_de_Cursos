using System;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;

public sealed class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TBInstrutores");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedNever();

        builder.Property(i => i.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Telefone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(i => i.Cpf)
            .IsRequired()
            .HasMaxLength(14);

        builder.HasIndex(i => i.Telefone)
            .IsUnique();

        builder.HasIndex(i => i.Cpf)
                    .IsUnique();
    }
}
