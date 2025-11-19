using GestionClinica.application.adapters.input;
using GestionClinica.domain.model;
using GestionClinica.domain.ports;
using GestionClinica.domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.application.usecases
{
    public class GenerarOrdenUseCase
    {
        private readonly IOrdenRepositorio _repoOrden;
        private readonly IPacienteRepositorio _repoPaciente;
        private readonly ServicioFacturacion _servicioFacturacion;

        public GenerarOrdenUseCase(IOrdenRepositorio repoOrden, IPacienteRepositorio repoPaciente)
        {
            _repoOrden = repoOrden;
            _repoPaciente = repoPaciente;
            _servicioFacturacion = new ServicioFacturacion(); // Instanciamos el servicio de dominio
        }

        public Orden Ejecutar(DatosOrdenInput input)
        {
            // 1. Validar que el paciente exista
            var paciente = _repoPaciente.BuscarPorCedula(input.CedulaPaciente);
            if (paciente == null) throw new Exception("El paciente no existe.");

            // 2. Crear la Orden base
            var nuevaOrden = new Orden
            {
                NumeroOrden = _repoOrden.ObtenerSiguienteNumeroOrden().ToString(),
                Paciente = paciente,
                Fecha = DateTime.Now,
                Pagada = false
            };

            // 3. Convertir los Inputs a Objetos del Dominio (Medicamento, Procedimiento...)
            bool tieneAyudaDiagnostica = false;
            bool tieneOtros = false;

            foreach (var itemInput in input.Items)
            {
                ItemOrden itemReal = null;

                if (itemInput.Tipo == "Medicamento")
                {
                    itemReal = new Medicamento
                    {
                        Nombre = itemInput.Nombre,
                        Costo = itemInput.Costo,
                        Cantidad = itemInput.Cantidad,
                        Dosis = itemInput.Dosis,
                        DuracionTratamiento = itemInput.Duracion
                    };
                    tieneOtros = true;
                }
                else if (itemInput.Tipo == "Procedimiento")
                {
                    itemReal = new Procedimiento
                    {
                        Nombre = itemInput.Nombre,
                        Costo = itemInput.Costo,
                        Cantidad = itemInput.Cantidad,
                        Frecuencia = itemInput.Frecuencia
                    };
                    tieneOtros = true;
                }
                else if (itemInput.Tipo == "AyudaDiagnostica")
                {
                    itemReal = new AyudaDiagnostica
                    {
                        Nombre = itemInput.Nombre,
                        Costo = itemInput.Costo,
                        Cantidad = itemInput.Cantidad
                    };
                    tieneAyudaDiagnostica = true;
                }

                if (itemReal != null) nuevaOrden.AgregarItem(itemReal);
            }

            // 4. Validar Regla de Negocio: No mezclar Ayudas Diagnósticas con Tratamientos
            if (tieneAyudaDiagnostica && tieneOtros)
            {
                throw new Exception("Regla violada: No se pueden recetar medicamentos/procedimientos junto con ayudas diagnósticas.");
            }

            // 5. Calcular Costos (Aquí se aplican los copagos y topes)
            _servicioFacturacion.CalcularTotalOrden(nuevaOrden);

            // 6. Guardar
            _repoOrden.Guardar(nuevaOrden);

            return nuevaOrden; // Retornamos la orden creada para mostrarla en pantalla
        }
    }
}
