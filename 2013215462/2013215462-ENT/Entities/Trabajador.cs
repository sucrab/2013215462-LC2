using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Trabajador
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
