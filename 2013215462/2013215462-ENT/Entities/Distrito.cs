using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Distrito
    {
        public int DistritoID { get; set; }

        public Provincia Provincia { get; set; }
        public int ProvinciaID { get; set; }

        public ICollection<Direccion> Direccion { get; set; }
        

        public string CadenaUbigeo { get; set; }

        public Distrito()
        {
            Direccion = new Collection<Direccion>();


        }
    }
}
