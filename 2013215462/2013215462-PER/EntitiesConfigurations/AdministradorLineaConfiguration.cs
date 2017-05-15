﻿using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.EntitiesConfigurations
{
    public class AdministradorLineaConfiguration : EntityTypeConfiguration<AdministradorLinea>
    {
        public AdministradorLineaConfiguration()
        {
            ToTable("AdministradorLinea");
            HasKey(a => a.AdministradorLineaID);
        }
    }
}
