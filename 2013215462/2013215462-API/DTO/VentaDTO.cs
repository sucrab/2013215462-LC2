using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class VentaDTO
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
    }
}