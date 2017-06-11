using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class AdministradorEquipo
    {
        public int AdministradorEquipoID { get; set; }

        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public int AdministradorCodigo { get; set; }

        public ICollection<EquipoCelular> EquipoCelular { get; set; }
     

        public AdministradorEquipo()
        {
            EquipoCelular = new Collection<EquipoCelular>();
        }
    }
}
