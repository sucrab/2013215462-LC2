﻿using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.EntitiesConfigurations
{
    public class AdministradorLineaConfiguration : EntityTypeConfiguration<AdministradorLinea>
    {
        public AdministradorLineaConfiguration()
        {
            ToTable("AdministradorLinea");
            HasKey(a => a.AdministradorLineaID);

            Property(a => a.AdministradorLineaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Nombre)
            // .IsRequired()
            // .HasMaxLength(255);

            //Property(v => v.Apellido)
            // .IsRequired()
            // .HasMaxLength(255);

            //Property(v => v.AdministradorCodigo)
            // .IsRequired();

        }
    }
}
