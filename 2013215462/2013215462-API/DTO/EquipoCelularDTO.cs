using _2013215462_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2013215462_API.DTO
{
    public class EquipoCelularDTO
    {
        public int EquipoCelularID { get; set; }

        //public string Modelo { get; set; }

        public AdministradorEquipo AdministradorEquipo { get; set; }
        public int AdministradorEquipoID { get; set; }

        public ICollection<Evaluacion> Evaluacion { get; set; }
        public int EvaluacionID { get; set; }
    }
}