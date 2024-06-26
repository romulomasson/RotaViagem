using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Repository.Maps
{   
    class RotaMap : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("Rota", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("RotaId").HasColumnType("int").HasMaxLength(4);
            builder.Property(e => e.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(e => e.Custo).HasColumnName("Custo").HasColumnType("decimal").HasMaxLength(9);
            builder.Property(e => e.Origem).HasColumnName("Origem").HasColumnType("varchar").HasMaxLength(3);
            builder.Property(e => e.Destino).HasColumnName("Destino").HasColumnType("varchar").HasMaxLength(3);
            builder.Property(e => e.Ativo).HasColumnName("Ativo").HasColumnType("bit").HasMaxLength(1);
            builder.Property(e => e.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").HasMaxLength(8);
            builder.Property(e => e.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime").HasMaxLength(8);
            builder.Property(e => e.UsuarioCadastro).HasColumnName("UsuarioCadastro").HasColumnType("int").HasMaxLength(4);
            builder.Property(e => e.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int").HasMaxLength(4);
        }
    }
}






