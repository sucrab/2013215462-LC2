using Ninject.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class TipoPlanDTO
    {
        public int TipoPlanID { get; set; }

        //public string Descripcion { get; set; }

        public ICollection<Plan> Plan { get; set; }

    }
}