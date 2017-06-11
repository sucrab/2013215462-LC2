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
    public class TipoTrabajadorConfiguration : EntityTypeConfiguration<TipoTrabajador>
    {
        public TipoTrabajadorConfiguration()
        {
            ToTable("TipoTrabajador");
            HasKey(a => a.TipoTrabajadorID);

            Property(a => a.TipoTrabajadorID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(v => v.Descripcion)
            // .IsRequired()
            // .HasMaxLength(255);

        }
    }
}
