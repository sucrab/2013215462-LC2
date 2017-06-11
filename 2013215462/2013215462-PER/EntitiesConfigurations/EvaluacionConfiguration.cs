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
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            ToTable("Evaluacion");
            HasKey(a => a.EvaluacionID);

            HasRequired(a => a.EquipoCelular)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.LineaTelefonica)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.CentroAtencion)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.Plan)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.Trabajador)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.EstadoEvaluacion)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.TipoEvaluacion)
                .WithMany(a => a.Evaluacion);

            HasRequired(a => a.Cliente)
                .WithMany(a => a.Evaluacion);

            Property(a => a.EvaluacionID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Descripcion)
            // .IsRequired()
            // .HasMaxLength(255);



           
            
        }
    }
}
