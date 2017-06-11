using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class ProvinciaDTO
    {
        public int ProvinciaID { get; set; }

        //public string Nombre { get; set; }

        public string CadenaUbigeo { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }


        public ICollection<Distrito> Distritos { get; set; }

    }
}