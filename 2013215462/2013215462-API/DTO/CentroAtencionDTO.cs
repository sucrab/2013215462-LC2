using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class CentroAtencionDTO
    {
        public int CentroAtencionID { get; set; }

        //public string NombreCentro { get; set; }


        public Direccion Direccion { get; set; }
        public int DireccionID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaID { get; set; }
    }
}