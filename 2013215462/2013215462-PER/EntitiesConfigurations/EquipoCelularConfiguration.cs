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
    public class EquipoCelularConfiguration : EntityTypeConfiguration<EquipoCelular>
    {
        public EquipoCelularConfiguration()
        {
            ToTable("EquipoCelular");
            HasKey(a => a.EquipoCelularID);

            HasRequired(a => a.AdministradorEquipo)
                .WithMany(e => e.EquipoCelular)
                .HasForeignKey(a => a.AdministradorEquipoID);

            Property(a => a.EquipoCelularID)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Modelo)
            // .IsRequired()
            // .HasMaxLength(255);

      
        }
    }
}
