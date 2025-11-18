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

        public void CalcularTotalOrden(Orden orden)
        {
            decimal costoRealServicios = orden.ValorTotalServicios;
            Paciente paciente = orden.Paciente;

            // Regla 1: Sin seguro o póliza inactiva -> Paga TODO [cite: 69]
            if (!paciente.TieneSeguroVigente())
            {
                orden.ValorCopagoPagar = costoRealServicios;
                return;
            }

            // Regla 2: Con seguro, pero superó el tope anual -> Paga $0 (Cubre la aseguradora) [cite: 68]
            if (paciente.AcumuladoCopagosAnio >= TOPE_ANUAL_COPAGO)
            {
                orden.ValorCopagoPagar = 0;
                return;
            }

            // Regla 3: Con seguro normal -> Paga Copago ($50.000) [cite: 67]
            orden.ValorCopagoPagar = VALOR_COPAGO;
        }
    }
}
