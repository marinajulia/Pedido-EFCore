﻿using CursoEntityFramework1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEntityFramework1.Data.Configurations {
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> {
        public void Configure(EntityTypeBuilder<Cliente> builder) {
            builder.ToTable("Clientes");//nome da tabela
            builder.HasKey(p => p.Id);//chave primária
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            builder.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired();
            builder.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
        }
    }
}
