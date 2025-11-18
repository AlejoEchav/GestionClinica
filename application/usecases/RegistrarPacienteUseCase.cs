using GestionClinica.application.adapters.input;
using GestionClinica.domain.model;
using GestionClinica.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.application.usecases
{
    public class RegistrarPacienteUseCase
    {
        // Declaramos la interfaz, no la implementación concreta
        private readonly IPacienteRepositorio _repositorio;

        // Constructor: Aquí nos "inyectan" el repositorio que vamos a usar
        public RegistrarPacienteUseCase(IPacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(DatosPacienteInput input)
        {
            // 1. VALIDACIÓN: Verificar si el paciente ya existe
            // Usamos el repositorio para buscar.
            var pacienteExistente = _repositorio.BuscarPorCedula(input.Cedula);

            if (pacienteExistente != null)
            {
                throw new Exception("Error: Ya existe un paciente con esa cédula.");
            }

            // 2. MAPEO: Convertir el 'Input' (que viene del formulario) a la Entidad 'Paciente' (del dominio)
            var nuevoPaciente = new Paciente
            {
                Cedula = input.Cedula,
                NombreCompleto = input.NombreCompleto,
                Telefono = input.Telefono,
                Direccion = input.Direccion,
                CorreoElectronico = input.Correo,
                FechaNacimiento = input.FechaNacimiento,
                Genero = input.Genero,

                // Datos de seguro
                NombreCompaniaSeguro = input.NombreSeguro,
                NumeroPoliza = input.NumeroPoliza,
                EstadoPoliza = input.EstadoPoliza,
                VigenciaPoliza = input.FinVigencia,

                // Emergencia
                NombreContactoEmergencia = input.NombreEmergencia,
                TelefonoEmergencia = input.TelefonoEmergencia,
                RelacionPaciente = input.Relacion,

                // Valores iniciales por defecto
                AcumuladoCopagosAnio = 0
            };

            // 3. GUARDADO: Mandar a guardar usando la interfaz
            _repositorio.Guardar(nuevoPaciente);
        }
    }
}
