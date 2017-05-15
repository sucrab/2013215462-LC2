using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class LineaTelefonica
    {
        public int LineaTelefonicaID { get; set; }

        public TipoLinea TipoLinea { get; set; }

        public AdministradorLinea AdministradorLinea { get; set; }
        public int AdministradorLineaID{ get; set; }

        public Venta Venta { get; set; }
        public int VentaID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }

    

        public LineaTelefonica()
        {
            Evaluacion = new Collection<Evaluacion>();
        }

    }
}
