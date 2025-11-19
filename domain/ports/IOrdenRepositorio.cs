using GestionClinica.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.ports
{
    public interface IOrdenRepositorio
    {
        void Guardar(Orden orden);
        List<Orden> ObtenerPorPaciente(string cedulaPaciente);
        // Método para generar un número de orden consecutivo (1, 2, 3...)
        int ObtenerSiguienteNumeroOrden();
    }
}
