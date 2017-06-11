using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class TipoTrabajadorDTO
    {
        public int TipoTrabajadorID { get; set; }

        //public string Descripcion { get; set; }

        public ICollection<Trabajador> Trabajador { get; set; }
        public int TrabajadorID { get; set; }
    }
}