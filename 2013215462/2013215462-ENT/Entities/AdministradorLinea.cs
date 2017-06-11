using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class AdministradorLinea
    {
        public int AdministradorLineaID { get; set; }

        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public int AdministradorCodigo { get; set; }

        public ICollection<LineaTelefonica> LineaTelefonica { get; set; }

        public AdministradorLinea()
        {
            LineaTelefonica = new Collection<LineaTelefonica>();
        }
    }
}
