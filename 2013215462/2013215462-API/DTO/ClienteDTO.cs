using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class ClienteDTO
    {
        public int ClienteID { get; set; }

        //public string Nombre { get; set; }
        //public string Apellido { get; set; }


        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaID { get; set; }

    }
}