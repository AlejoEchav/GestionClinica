using GestionClinica.domain.model;
using GestionClinica.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.infrastructure.database
{
    public class RepositorioOrdenMemoria : IOrdenRepositorio
    {
        // Lista estática para que los datos no se borren
        private static List<Orden> _dbOrdenes = new List<Orden>();

        public void Guardar(Orden orden)
        {
            _dbOrdenes.Add(orden);
        }

        public List<Orden> ObtenerPorPaciente(string cedulaPaciente)
        {
            return _dbOrdenes.Where(o => o.Paciente.Cedula == cedulaPaciente).ToList();
        }

        public int ObtenerSiguienteNumeroOrden()
        {
            return _dbOrdenes.Count + 1;
        }
    }
}
