using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class DepartamentoDTO
    {
        public int DepartamentoID { get; set; }

        //public string Nombre { get; set; }

        public ICollection<Provincia> Provincia { get; set; }
        public int ProvinciaID { get; set; }

    }
}