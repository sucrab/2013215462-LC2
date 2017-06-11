using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.EntitiesConfigurations
{
    public class TrabajadorConfiguration : EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfiguration()
        {
            ToTable("Trabajor");
            HasKey(a => a.TrabajadorID);

            HasRequired(a => a.TipoTrabajador)
                .WithMany(a => a.Trabajador);

            Property(a => a.TrabajadorID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Nombre)
            // .IsRequired()
            // .HasMaxLength(255);

            //Property(v => v.TrabajadorCodigo)
            // .IsRequired();
           

            //Property(v => v.Apellido)
            // .IsRequired()
            // .HasMaxLength(255);
        


        }
    }
}
