using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class TipoTrabajador
    {
        public int TipoTrabajadorID { get; set; }

        //public string Descripcion { get; set; }

        public ICollection<Trabajador> Trabajador { get; set; }
        public int TrabajadorID { get; set; }

        public TipoTrabajador()
        {
            Trabajador = new Collection<Trabajador>();
        }

    }
}
