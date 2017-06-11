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
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(a => a.DepartamentoID);


            Property(a => a.DepartamentoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Nombre)
            // .IsRequired()
            // .HasMaxLength(255);


            
        }

    }
}
