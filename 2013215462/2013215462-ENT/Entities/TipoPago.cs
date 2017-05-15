using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_ENT
{
    public class TipoPago
    {
        
        public int TipoPagoID { get; set; }

        public ICollection<Venta> Venta { get; set; }
        public int VentaID { get; set; }

        public TipoPago()
        {
            Venta = new Collection<Venta>();
        }


    }
}
