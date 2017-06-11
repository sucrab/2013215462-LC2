using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.ViewModels
{
    public class EvaluacionViewModel
    {

        public EstadoEvaluacion EstadoEvaluacion { get; set; }


        public TipoEvaluacion TipoEvaluacion { get; set; }


        public Cliente Cliente { get; set; }


        public Venta Venta { get; set; }


        public LineaTelefonica LineaTelefonica { get; set; }

        public EquipoCelular EquipoCelular { get; set; }

        public Plan Plan { get; set; }

        public Trabajador Trabajador { get; set; }


        public CentroAtencion CentroAtencion { get; set; }
    }
}