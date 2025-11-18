using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public abstract class ItemOrden
    {
        public int NumeroItem { get; set; } // 1, 2, 3...
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }

        public decimal CalcularSubtotal()
        {
            return Costo * Cantidad;
        }
    }
}
