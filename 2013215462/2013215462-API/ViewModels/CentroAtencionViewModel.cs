using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.ViewModels
{
    public class CentroAtencionViewModel
    {
        public int CentroAtencionID { get; set; }

        public Direccion Direccion { get; set; }     

        public ICollection<Evaluacion> Evaluacion { get; set; }
       
        public ICollection<Venta> Venta { get; set; }
       
    }
}