using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class CentroAtencion
    {
        public int CentroAtencionID { get; set; }

        //public string NombreCentro { get; set; }
      

        public Direccion Direccion { get; set; }
        public int DireccionID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaID { get; set; }

        public CentroAtencion()
        {
            Evaluacion = new Collection<Evaluacion>();
            Venta = new Collection<Venta>();
        }
    }
}
