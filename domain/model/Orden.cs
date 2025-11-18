using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Orden
    {
        public string NumeroOrden { get; set; } // ID único
        public Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public List<ItemOrden> Items { get; set; } = new List<ItemOrden>();

        // Totales calculados
        public decimal ValorTotalServicios => Items.Sum(i => i.CalcularSubtotal());
        public decimal ValorCopagoPagar { get; set; } // Lo que paga el paciente (50mil, 0 o todo)
        public bool Pagada { get; set; }

        public void AgregarItem(ItemOrden item)
        {
            // Asignamos el número de ítem automáticamente (1, 2, 3...)
            item.NumeroItem = Items.Count + 1;
            Items.Add(item);
        }
    }
}
