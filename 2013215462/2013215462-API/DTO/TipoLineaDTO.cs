using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class TipoLineaDTO
    {
        public int TipoLineaID { get; set; }
        //public string Descripcion { get; set; }

        public ICollection<LineaTelefonica> LineaTelefonica { get; set; }
        public int LineaTelefonicaID { get; set; }
    }
}