using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJobsCR.Models
{
    public class RegistroViewModel
    {
        // Usuario
        public string Cedula_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public string Password_Usuario { get; set; }
        public string Rol_Usuario { get; set; }

        // Estudiante
        public string Universidad_Estudiante { get; set; }
        public string Carrera_Estudiante { get; set; }
        public int? AnioAcademico_Estudiante { get; set; }
        public string Disponibilidad_Estudiante { get; set; }

        // Empresa
        public string CedulaJuridica_Empresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public string Email_Empresa { get; set; }
    }
}