using GestionClinica.application.adapters.input;
using GestionClinica.application.usecases;
using GestionClinica.infrastructure.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClinica.infrastructure.GUI
{
    public partial class FrmRegistroPaciente : Form
    {
        // Declaramos el Caso de Uso que vamos a utilizar
        private readonly RegistrarPacienteUseCase _registrarPacienteUseCase;

        public FrmRegistroPaciente()
        {
            InitializeComponent();

            // AQUÍ OCURRE LA MAGIA (Inyección de Dependencias Manual)
            // 1. Creamos el repositorio (la base de datos falsa)
            var repositorio = new RepositorioPacienteMemoria();

            // 2. Le damos el repositorio al caso de uso
            _registrarPacienteUseCase = new RegistrarPacienteUseCase(repositorio);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Empaquetamos los datos del formulario en el "Input"
                var input = new DatosPacienteInput
                {
                    Cedula = txtCedula.Text,
                    NombreCompleto = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    // Asumimos datos por defecto para probar rápido
                    Direccion = "Calle Falsa 123",
                    Correo = "prueba@test.com",
                    FechaNacimiento = DateTime.Now.AddYears(-20),
                    Genero = "Masculino",

                    // Datos del seguro (basado en el checkbox)
                    EstadoPoliza = chkSeguro.Checked,
                    NombreSeguro = chkSeguro.Checked ? "Sura" : "",
                    NumeroPoliza = chkSeguro.Checked ? "12345" : "",
                    FinVigencia = DateTime.Now.AddYears(1)
                };

                // 2. Llamamos al Caso de Uso para que haga el trabajo sucio
                _registrarPacienteUseCase.Ejecutar(input);

                // 3. Si no hubo error...
                MessageBox.Show("¡Paciente registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Si el Caso de Uso lanza error (ej: cédula repetida), lo mostramos aquí
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            chkSeguro.Checked = false;
        }
    }
}
