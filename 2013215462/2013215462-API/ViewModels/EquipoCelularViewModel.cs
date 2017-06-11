using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.ViewModels
{
    public class EquipoCelularViewModel
    {


        public AdministradorEquipo AdministradorEquipo { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
    }
}