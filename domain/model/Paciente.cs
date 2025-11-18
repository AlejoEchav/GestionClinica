using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Paciente : Persona
    {
        // Información de Seguro Médico
        public string NombreCompaniaSeguro { get; set; }
        public string NumeroPoliza { get; set; }
        public bool EstadoPoliza { get; set; } // true = Activa, false = Inactiva
        public DateTime VigenciaPoliza { get; set; } // Fecha fin contrato

        // Información de Contacto de Emergencia
        public string NombreContactoEmergencia { get; set; }
        public string RelacionPaciente { get; set; } // Ej: Padre, Esposo
        public string TelefonoEmergencia { get; set; }

        // Control financiero para la regla del millón de pesos
        public decimal AcumuladoCopagosAnio { get; set; }

        public bool TieneSeguroVigente()
        {
            // El seguro debe estar activo Y la fecha de hoy no debe haber pasado la vigencia
            return EstadoPoliza && DateTime.Now <= VigenciaPoliza;
        }
    }
}
