using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Persona
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; } // "Debe contener entre 1 y 10 dígitos"
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } // Masculino, Femenino, Otro

        public int CalcularEdad()
        {
            var edad = DateTime.Today.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
