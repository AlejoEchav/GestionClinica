using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public enum RolUsuario
    {
        RecursosHumanos,
        PersonalAdministrativo,
        Medico,
        Enfermera,
        SoporteInformacion
    }

    public class Usuario : Persona
    {
        public string NombreUsuario { get; set; } // "Único y máx 15 caracteres"
        public string Contrasena { get; set; }    // "Mayúscula, número, especial, min 8 chars"
        public RolUsuario Rol { get; set; }

        // Constructor vacío
        public Usuario() { }

        // Constructor para facilitar la creación rápida
        public Usuario(string cedula, string nombre, string usuario, string contrasena, RolUsuario rol)
        {
            Cedula = cedula;
            NombreCompleto = nombre;
            NombreUsuario = usuario;
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}
