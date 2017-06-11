using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class ContratoDTO
    {
        public int ContratoID { get; set; }

        //public string Descripcion { get; set; }


        public Venta Venta { get; set; }
        public int VentaID { get; set; }
    }
}