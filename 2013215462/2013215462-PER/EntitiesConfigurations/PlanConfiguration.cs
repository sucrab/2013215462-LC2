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
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plan");
            HasKey(a => a.PlanID);

            HasRequired(a => a.TipoPlan)
                .WithMany(a => a.Plan);

            Property(a => a.PlanID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Descripcion)
            // .IsRequired()
            // .HasMaxLength(255);

        }
    }
}
