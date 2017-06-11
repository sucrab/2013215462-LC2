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
    public class EstadoEvaluacionConfiguration : EntityTypeConfiguration<EstadoEvaluacion>
    {
        public EstadoEvaluacionConfiguration()
        {
            ToTable("EstadoEvaluacion");
            HasKey(a => a.EstadoEvaluacionID);

            Property(a => a.EstadoEvaluacionID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Estado)
            // .IsRequired()
            // .HasMaxLength(255);

        }
    }
}
