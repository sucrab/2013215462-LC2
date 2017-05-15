using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Direccion
    {
        public int DireccionID { get; set; }


        public string CadenaUbigeo { get; set; }

        public CentroAtencion CentroAtencion { get; set; }

        public int CentroAtencionID { get; set; }

        public Distrito Distrito { get; set; }
        public int DistritoID { get; set; }
    }
}
