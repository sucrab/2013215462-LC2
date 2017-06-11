using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class TrabajadorDTO
    {
        public int TrabajadorID { get; set; }

        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public int TrabajadorCodigo { get; set; }

        public TipoTrabajador TipoTrabajador { get; set; }


        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }
    }
}