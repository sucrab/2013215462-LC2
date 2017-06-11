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
    public class CentroAtencionConfiguration : EntityTypeConfiguration<CentroAtencion>
    {
        public CentroAtencionConfiguration()
        {
            ToTable("CentroAtencion");
            HasKey(a => a.CentroAtencionID);

            HasRequired(a => a.Direccion)
                .WithRequiredPrincipal(a => a.CentroAtencion);

            Property(a => a.CentroAtencionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.NombreCentro)
            // .IsRequired()
            // .HasMaxLength(255);

    


           

             
        }
    }
}
