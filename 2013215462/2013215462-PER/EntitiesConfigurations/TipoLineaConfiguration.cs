using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2013215462_PER.EntitiesConfigurations
{
    public class TipoLineaConfiguration : EntityTypeConfiguration<TipoLinea>
    {
        public TipoLineaConfiguration()
        {
            ToTable("TipoLinea");
            HasKey(a => a.TipoLineaID);
            
           
        }
    }
}
