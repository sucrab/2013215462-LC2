using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class Contrato
    {
        public int ContratoID { get; set; }

        public Venta Venta { get; set; }
        public int VentaID  { get; set; }

        public Contrato()
        {
  

        }

    }
}
