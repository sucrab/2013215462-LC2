using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class TipoEvaluacion
    {
        public int TipoEvaluacionID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }


        public TipoEvaluacion()
        {
            Evaluacion = new Collection<Evaluacion>();
        }


    }
}

