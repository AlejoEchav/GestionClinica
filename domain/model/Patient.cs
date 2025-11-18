using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Patient : Person
    {
        // Información de Seguro 
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public bool IsPolicyActive { get; set; } // "Estado de la póliza: booleano"
        public DateTime PolicyExpiration { get; set; }

        // Contacto de Emergencia [cite: 49]
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; } // "10 dígitos"
        public string EmergencyContactRelation { get; set; }

        // Acumulado de copagos del año (Para la regla del millón de pesos) [cite: 68]
        public decimal YearlyCopayAccumulated { get; set; }
    }
}
