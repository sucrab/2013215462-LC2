using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class LineaTelefonicaDTO
    {
        public int LineaTelefonicaID { get; set; }

        //public string Descripcion { get; set; }
        public TipoLinea TipoLinea { get; set; }

        public AdministradorLinea AdministradorLinea { get; set; }
        public int AdministradorLineaID { get; set; }

        public Venta Venta { get; set; }
        public int VentaID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }
    }
}