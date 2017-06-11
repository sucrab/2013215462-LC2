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
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            ToTable("Distrito");
            HasKey(a => a.DistritoID);

            HasRequired(a => a.Provincia)
                .WithMany(a => a.Distritos)
                .HasForeignKey(a => a.ProvinciaID);


            Property(a => a.DistritoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.CadenaUbigeo)
            //    .IsRequired()
            //    .HasMaxLength(255);

            //Property(v => v.Nombre)
            // .IsRequired()
            // .HasMaxLength(255);

        }
    }
}
