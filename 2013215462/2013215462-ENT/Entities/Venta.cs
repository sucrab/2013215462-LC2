using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Venta
    {
        public int VentaID { get; set; }

        //public string Descripcion { get; set; }

        public Cliente Cliente { get; set; }

        public TipoPago TipoPago { get; set; }
   
        public Contrato Contrato { get; set; }

        public Evaluacion Evaluacion { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public CentroAtencion CentroAtencion { get; set; }
        public int CentroAtencionID { get; set; }

        public Venta()
        {
       
        }


        
       

    }
}
