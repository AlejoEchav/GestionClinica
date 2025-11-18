using GestionClinica.domain.model;
using GestionClinica.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.infrastructure.database
{
    // Esta clase cumple el contrato "IPacienteRepositorio".
    // El sistema cree que guarda en una BD, pero en realidad guarda en una lista.
    public class RepositorioPacienteMemoria : IPacienteRepositorio
    {
        // "static" es vital aquí: significa que la lista es compartida por toda la aplicación.
        // Si quitas "static", la lista se borrará cada vez que hagas clic en un botón.
        private static List<Paciente> _baseDeDatosFalsa = new List<Paciente>();

        public void Guardar(Paciente paciente)
        {
            _baseDeDatosFalsa.Add(paciente);
        }

        public Paciente BuscarPorCedula(string cedula)
        {
            // Usamos LINQ para buscar en la lista
            return _baseDeDatosFalsa.FirstOrDefault(p => p.Cedula == cedula);
        }

        public List<Paciente> ObtenerTodos()
        {
            return _baseDeDatosFalsa;
        }

        public void Actualizar(Paciente paciente)
        {
            // Buscamos el viejo y lo reemplazamos
            var indice = _baseDeDatosFalsa.FindIndex(p => p.Cedula == paciente.Cedula);
            if (indice != -1)
            {
                _baseDeDatosFalsa[indice] = paciente;
            }
        }
    }
}
