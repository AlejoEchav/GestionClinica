using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClinica.domain.model
{
    public class Person
    {
        // Usamos "protected" para que solo las clases hijas (User, Patient) puedan cambiar el ID si es necesario
        public string Id { get; set; } // Cédula
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int CalculateAge()
        {
            // Lógica simple para calcular edad, útil para reglas de negocio futuras
            var age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
    }
}
