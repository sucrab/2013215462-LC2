using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class AdministradorEquipoDTO
    {
        public int AdministradorEquipoID { get; set; }

        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public int AdministradorCodigo { get; set; }

        public ICollection<EquipoCelular> EquipoCelular { get; set; }
    }
}