using GestionClinica.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.ports
{
    public interface IPacienteRepositorio
    {
        void Guardar(Paciente paciente);
        Paciente BuscarPorCedula(string cedula);
        List<Paciente> ObtenerTodos();
        void Actualizar(Paciente paciente);
    }
}
