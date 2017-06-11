using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Plan
    {
        public int PlanID { get; set; }

        //public string Descripcion { get; set; }
        public TipoPlan TipoPlan { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }

        public Plan()
        {
            Evaluacion = new Collection<Evaluacion>();
        }
        

    }
}
