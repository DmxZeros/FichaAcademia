using System;
using System.Collections.Generic;
using System.Text;
using FichaAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FichaAcademia.AcessoDados.Mapeamentos
{
    public class AdministradoresMap: IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder) 
        {
            builder.HasKey(a => a.AdministradorID);

            builder.Property(a => a.Nome).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Senha).IsRequired();

            builder.ToTable("Administradores");
        }
    }
}
