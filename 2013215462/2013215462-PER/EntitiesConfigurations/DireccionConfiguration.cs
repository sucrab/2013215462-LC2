﻿using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.EntitiesConfigurations
{
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccion");
            HasKey(a => a.DireccionID);

            HasRequired(d => d.Distrito)
              .WithMany(d => d.Direccion)
              .HasForeignKey(d => d.DistritoID);
            

        }
    }
}
