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
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {
        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(a => a.ProvinciaID);

            HasRequired(a => a.Departamento)
                .WithMany(a => a.Provincia)
                .HasForeignKey(a => a.DepartamentoID);

            Property(a => a.ProvinciaID)
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
