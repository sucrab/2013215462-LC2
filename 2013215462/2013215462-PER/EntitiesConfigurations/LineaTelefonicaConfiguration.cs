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
    public class LineaTelefonicaConfiguration : EntityTypeConfiguration<LineaTelefonica>
    {
        public LineaTelefonicaConfiguration()
        {
            ToTable("LineaTelefonica");
            HasKey(a => a.LineaTelefonicaID);

            HasRequired(a => a.AdministradorLinea)
                .WithMany(a => a.LineaTelefonica)
                .HasForeignKey(a => a.AdministradorLineaID);

            HasRequired(a => a.TipoLinea)
                .WithMany(a => a.LineaTelefonica);

            Property(a => a.LineaTelefonicaID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Descripcion)
            // .IsRequired()
            // .HasMaxLength(255);
 
        }
    }
}
