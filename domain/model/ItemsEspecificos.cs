using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Medicamento : ItemOrden
    {
        public string Dosis { get; set; } // Ej: "500mg"
        public string DuracionTratamiento { get; set; } // Ej: "7 días"
    }

    public class Procedimiento : ItemOrden
    {
        public string Frecuencia { get; set; } // Ej: "Cada 8 horas"
        public bool RequiereEspecialista { get; set; }
    }

    public class AyudaDiagnostica : ItemOrden
    {
        // Exámenes, Rayos X, etc.
        // No tiene campos extra según el PDF básico, pero hereda Costo y Nombre
    }
}
