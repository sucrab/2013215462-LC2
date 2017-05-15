using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class EquipoCelular
    {
        public int EquipoCelularID { get; set; }

        public AdministradorEquipo AdministradorEquipo { get; set; }
        public int AdministradorEquipoID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }
    }
}
