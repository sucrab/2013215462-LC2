using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class DireccionDTOcs
    {
        public int DireccionID { get; set; }

        //public string Direccion { get; set; }

        public string CadenaUbigeo { get; set; }

        public CentroAtencion CentroAtencion { get; set; }

        public int CentroAtencionID { get; set; }

        public Distrito Distrito { get; set; }
        public int DistritoID { get; set; }
    }
}