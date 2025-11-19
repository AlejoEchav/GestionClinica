using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.application.adapters.input
{
    // Esta clase representa "El Carrito de Compras" que viene de la pantalla
    public class DatosOrdenInput
    {
        public string CedulaPaciente { get; set; }
        public string CedulaMedico { get; set; }
        public List<ItemInput> Items { get; set; } = new List<ItemInput>();
    }

    public class ItemInput
    {
        public string Tipo { get; set; } // "Medicamento", "Procedimiento", "AyudaDiagnostica"
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }

        // Campos opcionales dependiendo del tipo
        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public string Frecuencia { get; set; }
    }
}
