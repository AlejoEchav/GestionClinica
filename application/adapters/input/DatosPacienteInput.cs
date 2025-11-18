using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.application.adapters.input
{
    // Esta clase es un DTO (Data Transfer Object) simple.
    // Solo sirve para recibir los datos que el usuario escribió en las cajas de texto.
    public class DatosPacienteInput
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }

        // Datos del Seguro
        public string NombreSeguro { get; set; }
        public string NumeroPoliza { get; set; }
        public bool EstadoPoliza { get; set; }
        public DateTime FinVigencia { get; set; }

        // Contacto Emergencia
        public string NombreEmergencia { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string Relacion { get; set; }
    }
}
