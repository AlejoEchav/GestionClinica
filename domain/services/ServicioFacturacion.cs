using GestionClinica.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.services
{
    public class ServicioFacturacion
    {
        private const decimal VALOR_COPAGO = 50000m;
        private const decimal TOPE_ANUAL_COPAGO = 1000000m;

        public decimal CalcularPagoPaciente(Paciente paciente, decimal costoTotalServicio)
        {
            // Regla 1: Si la póliza NO está activa o vencida, paga el 100%
            if (!paciente.TieneSeguroVigente())
            {
                return costoTotalServicio;
            }

            // Regla 2: Si tiene seguro, pero ya pagó más de 1 millón este año, paga 0
            if (paciente.AcumuladoCopagosAnio >= TOPE_ANUAL_COPAGO)
            {
                return 0;
            }

            // Regla 3: Si tiene seguro y no ha superado el tope, paga el copago fijo
            return VALOR_COPAGO;
        }
    }
}
