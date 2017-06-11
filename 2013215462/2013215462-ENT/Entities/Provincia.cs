using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Provincia
    {
        public int ProvinciaID { get; set; }

        //public string Nombre { get; set; }

        public string CadenaUbigeo { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }


        public ICollection<Distrito> Distritos { get; set; }


        public Provincia()
        {
            Distritos = new Collection<Distrito>();

        }
        
    }
}
